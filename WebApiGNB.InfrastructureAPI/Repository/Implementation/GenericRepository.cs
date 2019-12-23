using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiGNB.InfrastructureAPI.EntityModel;
using WebApiGNB.InfrastructureAPI.Repository.Contract;


namespace WebApiGNB.InfrastructureAPI.Data.Repository
{
    public sealed class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private GNBDataContext Db { get; }

        public GenericRepository(GNBDataContext context)
        {
            Db = context;
        }

        public IQueryable<T> GetAll()
        {
            return Db.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Db.Set<T>().Where(predicate);
        }

        public async Task SaveAndCommitAsync(T entity)
        {
            try
            {
                Db.Set<T>().Add(entity);
                await Db.SaveChangesAsync();
            }
            catch (DbEntityValidationException e) { }
        }
        public void Add(T entity)
        {
            try
            {
                Db.Set<T>().Add(entity);
            }
            catch (DbEntityValidationException)
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public bool Exists(T entity)
        {
            return Db.Set<T>().Any(e => e == entity);

        }
        public T AddAndGet(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            Db.Set<T>().Remove(entity);
        }

        public void DeleteList(List<T> entity)
        {
            Db.Set<T>().RemoveRange(entity);
        }

        public bool Edit(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return true;
        }
        public void Save()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public async Task SaveAsync()
        {
            try
            {
                await Db.SaveChangesAsync();
            }
            catch (DbEntityValidationException) { }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
        public bool SaveChanges(T entity)
        {
            if (Db.Entry(entity).State == EntityState.Detached)
            {
                Db.Set<T>().Attach(entity);
            }
            Save();
            return true;
        }

        public T FindById(int id)
        {
            return Db.Set<T>().Find(id);
        }


        public void Attach(T entity)
        {
            Db.Set<T>().Attach(entity);
        }





    }
}
