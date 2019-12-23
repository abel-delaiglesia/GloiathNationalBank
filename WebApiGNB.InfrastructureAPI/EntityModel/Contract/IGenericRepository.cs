using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace REMO.Almacen.Infrastructure.Data.Repository.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        void DeleteList(List<T> entity);
        Task SaveAsync();
        Task SaveAndCommitAsync(T entity);
        void Attach(T entity);
        bool Exists(T entity);
        void Add(T entity);
        T AddAndGet(T entity);
        void Save();
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindById(int id);
        bool Edit(T entity);
        void Delete(T entity);
        bool SaveChanges(T entity);

    }
}