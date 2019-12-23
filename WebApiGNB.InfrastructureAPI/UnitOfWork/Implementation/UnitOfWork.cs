using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApiGNB.InfrastructureAPI.UnitOfWork.Contract;
using WebApiGNB.InfrastructureAPI.Repository.Contract;
using WebApiGNB.InfrastructureAPI.EntityModel;
using WebApiGNB.InfrastructureAPI.Data.Repository;

namespace WebApiGNB.InfrastructureAPI.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GNBDataContext _context;

        private IGenericRepository<M_Conversion> _m_ConversionRepository;
        private IGenericRepository<M_Transactions> _m_TransactionsRepository;

        private IGenericRepository<T_ConvertedTransacctions> _t_ConvertedTransacctionsRepository;

        private bool _disposed;


        public UnitOfWork()
        {
            _context = new GNBDataContext();
        }

        //Repositories
        public IGenericRepository<M_Conversion> M_ConversionRepository => _m_ConversionRepository ??
          (_m_ConversionRepository = new GenericRepository<M_Conversion>(_context));
        public IGenericRepository<M_Transactions> M_TransactionsRepository => _m_TransactionsRepository ??
          (_m_TransactionsRepository = new GenericRepository<M_Transactions>(_context));
       
        public IGenericRepository<T_ConvertedTransacctions> T_ConvertedTransacctionsRepository => _t_ConvertedTransacctionsRepository ??
          (_t_ConvertedTransacctionsRepository = new GenericRepository<T_ConvertedTransacctions>(_context));
 

        #region ExecuteStore
        public IEnumerable<T> ExecuteWithStoreProcedureNoTransaction<T>(string query, params object[] parameters)
        {
            return _context.Database.SqlQuery<T>(query, parameters);
        }
        public int ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return _context.Database.ExecuteSqlCommand("EXEC " + query, parameters);
        }
        public IEnumerable<T> ExecuteWithStoreProcedure<T>(string query, params object[] parameters)
        {
            using (var trans = _context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    var result = _context.Database.SqlQuery<T>(query, parameters);
                    trans.Commit();
                    return result;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    trans?.Dispose();
                }
            }

        }
        public void ExecuteWithStoreProcedureNoTransaction(string query, params object[] parameters)
        {
            _context.Database.ExecuteSqlCommand(query, parameters);
        }
        public void ExecuteWithStoreProcedure(string query, params object[] parameters)
        {

            using (var trans = _context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    _context.Database.ExecuteSqlCommand(query, parameters);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    trans?.Dispose();
                }
            }

        }

        #endregion


        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing) _context.Dispose();
            _disposed = true;
        }
    }
}
