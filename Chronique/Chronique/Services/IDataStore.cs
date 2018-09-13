using System.Collections.Generic;
using System.Threading.Tasks;
using Chronique.Models;

namespace Chronique.Services
{
    public interface IDataStore<T> where T : BaseModel
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false, string query = null);
    }
}