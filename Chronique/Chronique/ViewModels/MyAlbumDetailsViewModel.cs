using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Chronique.Models;
using Chronique.Services;
using Xamarin.Forms;

namespace Chronique.ViewModels
{
    public class MyAlbumDetailsViewModel : BaseViewModel<Album>
    {
        private Album item;
        public Album Item
        {
            get => item;
            set
            {
                item = value;
                OnPropertyChanged("Item");
            }
        }

        private string tracksNumber;
        public string TracksNumber
        {
            get => tracksNumber;
            set
            {
                tracksNumber = value;
                OnPropertyChanged("TracksNumber");
            }
        }

        public GenericRequestObject Id { get; set; }
        public IDataStore<Album> DataStore => DependencyService.Get<IDataStore<Album>>() ?? new MyAlbumMockStore();
        public Command LoadItemsCommand { get; set; }
        public MyAlbumDetailsViewModel(GenericRequestObject id)
        {
            Id = id;
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand((string)query));
        }

        public virtual async Task ExecuteLoadItemsCommand(string query = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                Item = await DataStore.GetItemAsync(query, Id.Subtitle);
                TracksNumber = Item.TrackList.Count + "";
                Title = Item?.Name;
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
