using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Chronique.Models;
using Realms;

namespace Chronique.Services
{
    public class ICloudStoreImpl<T> : ICloudStore<T>
        where T : RealmObject
    {
        protected ObservableCollection<T> items;

        public ICloudStoreImpl()
        {
        }

        public virtual async Task<bool> AddItemAsync(T item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public virtual async Task<bool> UpdateItemAsync(T item)
        {
            var _item = items.Where((T arg) => (arg as BaseModel).Id == (item as BaseModel).Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public virtual async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((T arg) => (arg as BaseModel).Id.ToString() == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public virtual async Task<T> GetItemAsync(string id, string additionnalInfos = null)
        {
            return await Task.FromResult(items.FirstOrDefault(s => (s as BaseModel).Id.ToString() == id));
        }

        public virtual async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false, string query = null)
        {
            return await Task.FromResult(items);
        }
    }
}