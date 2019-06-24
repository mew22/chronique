using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronique.Customs;
using Chronique.Layout;
using Chronique.Models;
using Chronique.Services;
using Plugin.Connectivity;
using Realms;
using Xamarin.Forms;

namespace Chronique.ViewModels
{
    [Preserve(AllMembers = true)]
    public class BaseListViewModel<T, U, V> : BaseViewModel<T>
        where T : RealmObject
        where U : ContentPage
        where V : ICloudStore<T>, new()
    {
        public Command LoadItemsCommand { get; set; }

        private ObservableCollection<T> items;

        public ObservableCollection<T> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("items");
            }
        }

        public bool IsEmpty => this.Items.Count <= 0;
        public bool IsNotEmpty => this.Items.Count > 0;


        public ICloudStore<T> DataStore => DependencyService.Get<ICloudStore<T>>() ?? new V();

        public BaseListViewModel()
        {
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand((string) query));
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
                if (!CrossConnectivity.Current.IsConnected)
                {
                    this.OnPropertyChanged("IsEmpty");
                    this.OnPropertyChanged("IsNotEmpty");
                    DependencyService.Get<IMessageToast>().LongAlert("No internet connexion");
                    return;
                }

                var loaded_items = await DataStore.GetItemsAsync(true, query);
                Items.Clear();
                foreach (var item in loaded_items)
                {
                    Items.Add(item);
                }

                this.OnPropertyChanged("IsEmpty");
                this.OnPropertyChanged("IsNotEmpty");
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