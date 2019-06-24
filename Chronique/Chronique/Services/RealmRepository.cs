using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Chronique.Services;
using Realms;

//using Realms;
//[assembly: Xamarin.Forms.Dependency(typeof(RealmRepository<>))]
namespace Chronique.Services
{
    [Preserve(AllMembers = true)]
    public class RealmRepository<TEntity> : ICacheStore<TEntity> where TEntity : RealmObject, new()
    {
        private readonly Realm realmInstance;

        public RealmRepository()
        {
            //realmInstance = RealmSingleton.Instance.RealmInstance;
            realmInstance = Realm.GetInstance();
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync()
        {
//            throw new NotImplementedException();
            return await Task.FromResult(realmInstance.All<TEntity>());
        }

        public virtual async Task<TEntity> GetSingleByIdAsync(string Id)
        {
//            throw new NotImplementedException();
            return await Task.FromResult(realmInstance.Find<TEntity>(Id));
        }

        public virtual async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
//            throw new NotImplementedException();
            return await Task.FromResult(realmInstance.All<TEntity>().Where(expression));
        }

        public virtual async void InsertAsync(TEntity obj)
        {
            await realmInstance.WriteAsync(tmpRealm => { tmpRealm.Add(obj); });
        }

        public virtual async void UpdateAsync(TEntity obj)
        {
            //            realmInstance.Write(() => { realmInstance.Add(obj, true); });
            await realmInstance.WriteAsync(tmpRealm => { tmpRealm.Add(obj, true); });
        }

        public virtual async void DeleteAsync(string Id)
        {
            var entity = await GetSingleByIdAsync(Id);
            DeleteAsync(entity);
        }

        public virtual async void DeleteAsync(TEntity obj)
        {
            await realmInstance.WriteAsync(tmpRealm => { tmpRealm.Remove(obj); });
        }

        public IQueryable<TEntity> GetAll()
        {
            return realmInstance.All<TEntity>();
        }

        public TEntity GetSingleById(string Id)
        {
            return realmInstance.Find<TEntity>(Id);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return realmInstance.All<TEntity>().Where(expression);
        }

        public virtual void Insert(TEntity obj)
        {
            realmInstance.Write(() => { realmInstance.Add(obj); });
        }

        public virtual void Insert(Action action)
        {
            realmInstance.Write(action);
        }

        public void Update(TEntity obj)
        {
            realmInstance.Write(() => { realmInstance.Add(obj, true); });
        }

        public void Delete(string Id)
        {
            var entity = GetSingleById(Id);
            Delete(entity);
        }

        public void Delete(TEntity obj)
        {
            realmInstance.Write(() => { realmInstance.Remove(obj); });
        }

        public TEntity DetachObject(TEntity Model)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TEntity>(
                Newtonsoft.Json.JsonConvert.SerializeObject(Model)
                    .Replace(",\"IsManaged\":true", ",\"IsManaged\":false")
            );
        }
    }
}