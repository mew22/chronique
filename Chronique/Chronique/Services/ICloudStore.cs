using System.Collections.Generic;
using System.Threading.Tasks;
using Chronique.Models;
using Realms;

namespace Chronique.Services
{
    public interface ICloudStore<T> where T : RealmObject
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id, string additionnalInfos = null);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false, string query = null);
    }
}