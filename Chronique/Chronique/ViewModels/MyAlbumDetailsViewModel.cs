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
        public Album DataFromArtistPage { get; set; }
        public IDataStore<Album> DataStore => DependencyService.Get<IDataStore<Album>>() ?? new MyAlbumMockStore();
        public Command LoadItemsCommand { get; set; }
        public MyAlbumDetailsViewModel(GenericRequestObject id)
        {
            Id = id;
            DataFromArtistPage = null;
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand((string)query));
        }
        public MyAlbumDetailsViewModel(Album data)
        {
            DataFromArtistPage = data;
            Id = null;
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand(null));
        }

        public virtual async Task ExecuteLoadItemsCommand(string query = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                if (DataFromArtistPage != null && DataFromArtistPage.TrackList.Count != 0)
                {
                    Item = DataFromArtistPage;
                }
                else if(DataFromArtistPage != null && DataFromArtistPage.ProviderId != null)
                {
                    Item = await DataStore.GetItemAsync(DataFromArtistPage.ProviderId ?? DataFromArtistPage.Name, DataFromArtistPage.MainArtist);
                }
                else if(Id?.ProviderId != null)
                {
                    //Id.Subtitle temp fix to get artist if mbid not exist (pass album name and artist name...)
                    Item = await DataStore.GetItemAsync(Id.ProviderId, Id.Subtitle);
                }
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
