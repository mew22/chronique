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
    public class MyArtistDetailsViewModel : BaseViewModel<Artiste>
    {
        private Artiste item;
        public Artiste Item
        {
            get => item;
            set
            {
                item = value;
                OnPropertyChanged("Item");
            }
        }

        public ObservableCollection<string> Links { get; set; }
        public Dictionary<string, ICommand> OpenRelations { get; set; }

        public GenericRequestObject Id { get; set; }
        public Artiste FromArtistPage { get; set; }
        public IDataStore<Artiste> DataStore => DependencyService.Get<IDataStore<Artiste>>() ?? new MyArtistMockStore();
        public Command LoadItemsCommand { get; set; }
        public MyArtistDetailsViewModel(GenericRequestObject id)
        {
            Id = id;
            FromArtistPage = null;
            Links = new ObservableCollection<string>();
            var comparer = StringComparer.OrdinalIgnoreCase;
            OpenRelations = new Dictionary<string, ICommand>(comparer);
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand((string)query));
        }
        public MyArtistDetailsViewModel(Artiste id)
        {
            Id = null;
            FromArtistPage = id;
            Links = new ObservableCollection<string>();
            var comparer = StringComparer.OrdinalIgnoreCase;
            OpenRelations = new Dictionary<string, ICommand>(comparer);
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand((string)query));
        }

        public virtual async Task ExecuteLoadItemsCommand(string query = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Links.Clear();
                OpenRelations.Clear();

                // use Id.Title as temp workaround (artist name)
                if (FromArtistPage != null)
                {
                    Item = await DataStore.GetItemAsync(FromArtistPage.ProviderId, FromArtistPage.Pseudo);
                }
                else if (Id != null)
                {
                    Item = await DataStore.GetItemAsync(Id.ProviderId, Id.Title);
                }

                Title = Item?.Pseudo;

                foreach (var rel in Item.Relations)
                {
                    string url = null;
                    switch (rel.Key)
                    {
                        case var testHome when testHome.Contains("home"):
                            url = "resource://Chronique.Images.SocialNetwork.home.png";
                            break;
                        case var testFacebook when rel.Value.Contains("facebook"):
                            url = "resource://Chronique.Images.SocialNetwork.facebook.png";
                            break;
                        case var testTwitter when rel.Value.Contains("twitter"):
                            url = "resource://Chronique.Images.SocialNetwork.twitter.png";
                            break;
                        case var testInsta when rel.Value.Contains("insta"):
                            url = "resource://Chronique.Images.SocialNetwork.instagram.png";
                            break;
                        case var testWikipedia when testWikipedia.Contains("wikipedia"):
                            url = "resource://Chronique.Images.SocialNetwork.wordpress.png";
                            break;
                        case var testYoutube when testYoutube.Contains("youtube"):
                            url = "resource://Chronique.Images.SocialNetwork.youtube.png";
                            break;
                        case var testSpotify when testSpotify.Contains("spotify"):
                            url = "resource://Chronique.Images.SocialNetwork.spotify.png";
                            break;
                        case var testSoundcloud when testSoundcloud.Contains("soundcloud"):
                            url = "resource://Chronique.Images.SocialNetwork.soundcloud.png";
                            break;
                        case var testAppStore when rel.Value.Contains("apple"):
                            url = "resource://Chronique.Images.SocialNetwork.apple.png";
                            break;
                        case var testPlayStore when rel.Value.Contains("play.google"):
                            url = "resource://Chronique.Images.SocialNetwork.google-play.png";
                            break;
                        default:
                            break;
                    }
                    if (url != null && !OpenRelations.ContainsKey(url))
                        OpenRelations.Add(url, new Command(() => Device.OpenUri(new Uri(rel.Value))));
                }

                foreach (var it in OpenRelations.Keys)
                {
                    Links.Add(it);
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
