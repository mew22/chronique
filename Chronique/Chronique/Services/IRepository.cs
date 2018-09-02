using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Chronique.Services
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetSingleById(int Id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(int Id);
        void Delete(TEntity obj);
    }
}