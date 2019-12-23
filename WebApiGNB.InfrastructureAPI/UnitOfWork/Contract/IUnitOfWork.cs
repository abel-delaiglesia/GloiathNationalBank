using WebApiGNB.InfrastructureAPI.EntityModel;
using WebApiGNB.InfrastructureAPI.Repository;
using WebApiGNB.InfrastructureAPI.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebApiGNB.InfrastructureAPI.UnitOfWork.Contract
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<M_Conversion> M_ConversionRepository { get; }
        IGenericRepository<M_Transactions> M_TransactionsRepository { get; }
        IGenericRepository<T_ConvertedTransacctions> T_ConvertedTransacctionsRepository { get; }

        IEnumerable<T> ExecuteWithStoreProcedureNoTransaction<T>(string query, params object[] parameters);
        IEnumerable<T> ExecuteWithStoreProcedure<T>(string query, params object[] parameters);
        void ExecuteWithStoreProcedureNoTransaction(string query, params object[] parameters);
        void ExecuteWithStoreProcedure(string query, params object[] parameters);
        int ExecWithStoreProcedure(string query, params object[] parameters);
        void Save();
        Task SaveAsync();
    }
}

