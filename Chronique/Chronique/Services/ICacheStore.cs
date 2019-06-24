using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chronique.Services
{
    [Preserve(AllMembers = true)]
    public interface ICacheStore<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetSingleByIdAsync(string Id);
        TEntity GetSingleById(string Id);
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        void Insert(TEntity obj);
        void InsertAsync(TEntity obj);
        void Insert(Action action);
        void UpdateAsync(TEntity obj);
        void Update(TEntity obj);
        void DeleteAsync(string Id);
        void Delete(string Id);
        void DeleteAsync(TEntity obj);
        void Delete(TEntity obj);
        TEntity DetachObject(TEntity Model);
    }
}