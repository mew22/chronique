using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
//using Realms;

namespace Chronique.Services
{
    public class RealmRepository<TEntity> //: IRepository<TEntity>  where TEntity : RealmObject, new()
    {
//        private Realm realmInstance;
        public RealmRepository()
        {
//            realmInstance = Realm.GetInstance();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
            //            return realmInstance.All<TEntity>();
        }

        public virtual TEntity GetSingleById(int Id)
        {
            throw new NotImplementedException();
            //            return realmInstance.Find<TEntity>(Id);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
//            return realmInstance.All<TEntity>().Where(expression);
        }

        public virtual void Insert(TEntity obj)
        {
//            realmInstance.Write(() =>
//            {
//                realmInstance.Add(obj);
//            });
        }

        public virtual void Update(TEntity obj)
        {
//            realmInstance.Write(() =>
//            {
//                realmInstance.Add(obj, true);
//            });
        }

        public virtual void Delete(int Id)
        {
            var entity = GetSingleById(Id);
            Delete(entity);
        }

        public virtual void Delete(TEntity obj)
        {
//            realmInstance.Write(() =>
//            {
//                realmInstance.Remove(obj);
//            });
        }
    }
}