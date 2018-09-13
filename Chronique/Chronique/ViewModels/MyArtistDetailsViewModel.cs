using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public ObservableCollection<string> Relations;
        public Dictionary<string, ICommand> OpenRelations;

        public string Id { get; set; }
        public IDataStore<Artiste> DataStore => DependencyService.Get<IDataStore<Artiste>>() ?? new MyArtistMockStore();
        public Command LoadItemsCommand { get; set; }
        public MyArtistDetailsViewModel(string id)
        {
            Id = id;
            Relations = new ObservableCollection<string>{ "resource://Chronique.Images.SocialNetwork.home_page.png", "resource://Chronique.Images.SocialNetwork.facebook_page.png"};
            OpenRelations = new Dictionary<string, ICommand>();
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand((string)query));
        }

        public virtual async Task ExecuteLoadItemsCommand(string query = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Relations.Clear();
                OpenRelations.Clear();
                Item = await DataStore.GetItemAsync(query);
                Title = Item?.Pseudo;

                foreach (var rel in Item.Relations)
                {
                    string url = null;
                    switch (rel.Key)
                    {
                        case var testHome when testHome.Contains("home"):
                            url = "resource://Chronique.Images.SocialNetwork.home_page.png";
                            break;
                        case var testFacebook when rel.Value.Contains("facebook"):
                            url = "resource://Chronique.Images.SocialNetwork.facebook_page.png";
                            break;
                        case var testTwitter when rel.Value.Contains("twitter"):
                            url = "resource://Chronique.Images.SocialNetwork.twitter_page.png";
                            break;
                        case var testInsta when rel.Value.Contains("insta"):
                            url = "resource://Chronique.Images.SocialNetwork.insta_page.png";
                            break;
                        case var testWikipedia when testWikipedia.Contains("wikipedia"):
                            url = "resource://Chronique.Images.SocialNetwork.wikipedia_page.png";
                            break;
                        case var testYoutube when testYoutube.Contains("youtube"):
                            url = "resource://Chronique.Images.SocialNetwork.youtube_page.png";
                            break;
                        case var testSpotify when testSpotify.Contains("spotify"):
                            url = "resource://Chronique.Images.SocialNetwork.spotify_page.png";
                            break;
                        case var testDiscogs when testDiscogs.Contains("discog"):
                            url = "resource://Chronique.Images.SocialNetwork.discogs_page.png";
                            break;
                        default:
                            break;
                    }
                    if (url != null && !OpenRelations.ContainsKey(url))
                        OpenRelations.Add(url, new Command(() => Device.OpenUri(new Uri(rel.Value))));
                }

                foreach (var it in OpenRelations.Keys)
                {
//                    Relations.Add(it);
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
