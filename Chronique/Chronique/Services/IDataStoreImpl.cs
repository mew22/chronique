using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Chronique.Models;

namespace Chronique.Services
{
    public class IDataStoreImpl<T> : IDataStore<T>
        where T : BaseModel
    {
        protected ObservableCollection<T> items;

        public IDataStoreImpl()
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
            var _item = items.Where((T arg) => (arg as BaseModel).Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public virtual async Task<T> GetItemAsync(string id, string additionnalInfos = null)
        {
            return await Task.FromResult(items.FirstOrDefault(s => (s as BaseModel).Id == id));
        }

        public virtual async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false, string query = null)
        {
            return await Task.FromResult(items);
        }
    }
}