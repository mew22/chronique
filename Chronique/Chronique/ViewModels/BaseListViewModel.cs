using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronique.Models;
using Chronique.Services;
using Xamarin.Forms;

namespace Chronique.ViewModels
{
    public class BaseListViewModel<T, U, V> : BaseViewModel<T>
        where T : BaseModel
        where U : ContentPage 
        where V : IDataStore<T>, new ()
    {
        public Command LoadItemsCommand { get; set; }

        private ObservableCollection<T> items;
        public ObservableCollection<T> Items
        {
            get { return items;}
            set
            {
                items = value;
                OnPropertyChanged("items");
            }
        }

        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>() ?? new V();
        public BaseListViewModel()
        {
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand((string)query));
            MessagingCenter.Subscribe<U, T>(this, "Ajouter un Item", async (obj, item) =>
            {
                Items.Add(item);
                await DataStore.AddItemAsync(item);
            });
        }

        public virtual async Task ExecuteLoadItemsCommand(string query = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                
                var loaded_items = await DataStore.GetItemsAsync(true, query);
                Items.Clear();
                foreach (var item in loaded_items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

