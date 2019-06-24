using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Chronique.Customs;
using Chronique.Helpers;
using Chronique.Layout;
using Chronique.Models;
using Chronique.Services;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace Chronique.ViewModels
{
    [Preserve(AllMembers = true)]
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

        public ICloudStore<Artiste> DataStore =>
            DependencyService.Get<ICloudStore<Artiste>>() ?? new MyArtistCloudStore();

        //        public ICacheStore<Artiste> CacheStore => DependencyService.Get<ICacheStore<Artiste>>() ?? new RealmRepository<Artiste>();
        public ICacheStore<Artiste> CacheStore = new RealmRepository<Artiste>();

        private bool tracked = false;

        public bool Tracked
        {
            get => tracked;
            set
            {
                tracked = value;
                OnPropertyChanged("Tracked");
            }
        }

        public Command LoadItemsCommand { get; set; }

        public MyArtistDetailsViewModel(GenericRequestObject id)
        {
            Id = id;
            FromArtistPage = null;
            Links = new ObservableCollection<string>();
            var comparer = StringComparer.OrdinalIgnoreCase;
            OpenRelations = new Dictionary<string, ICommand>(comparer);
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand((string) query));
        }

        public MyArtistDetailsViewModel(Artiste id)
        {
            Id = null;
            FromArtistPage = id;
            Links = new ObservableCollection<string>();
            var comparer = StringComparer.OrdinalIgnoreCase;
            OpenRelations = new Dictionary<string, ICommand>(comparer);
            LoadItemsCommand = new Command(async (query) => await ExecuteLoadItemsCommand((string) query));
        }

        public void OnDisappearing()
        {
            if (!Tracked && CacheStore.GetSingleById(Item.ProviderId) != null)
                CacheStore.Delete(Item.ProviderId);
            else if (CacheStore.GetSingleById(Item.ProviderId) == null)
            {
                Item.IsTracked = true;
                CacheStore.Update(Item);
            }
            else
            {
                CacheStore.Update(Item);
                Action tracked = () => { Item.IsTracked = true; };
                CacheStore.Insert(tracked);
            }
        }

        public async void SwitchPersistedArtist(bool value)
        {
//            string providerId = null;
//
//            if (FromArtistPage != null)
//                providerId = FromArtistPage.ProviderId;
//            else
//            {
//                providerId = Id.ProviderId;
//            }
//            var tmp = CacheStore.GetSingleById(providerId);
//
//            if (value == false)
//            {
//                if (tmp != null)
//                {
//                    try
//                    {
//                        // TODO: Find a way to remove this workaround (realm.copy)
//                        //Item = CacheStore.DetachObject(Item);
//                        Item.IsTracked = false;
//                    }
//                    catch (Exception e)
//                    {
//                        Console.WriteLine("error: " + e);
//                        //TODO: show error message UI
//                        Tracked = true;
//                    }
//                }
//            }
//            else
//            {
//                try { 
//                if (tmp == null)
//                {
//                    Item.IsTracked = true;
//                }
//                }catch (Exception e)
//                {
//                    Console.WriteLine("error: " + e);
//                    //TODO: show error message UI
//                    Tracked = false;
//                }
//            }
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

                //search in cache before request


                // use Id.Title as temp workaround (artist name)
                if (FromArtistPage != null)
                {
                    Item = await CacheStore.GetSingleByIdAsync(FromArtistPage.ProviderId);
                    if (Item == null || !Item.IsTracked)
                    {
                        if (!CrossConnectivity.Current.IsConnected)
                        {
                            DependencyService.Get<IMessageToast>().LongAlert("No internet connexion");
                            return;
                        }

                        Item = await DataStore.GetItemAsync(FromArtistPage.ProviderId, FromArtistPage.Pseudo);
                    }

                    else
                    {
                        Tracked = true;
                    }
                }
                else if (Id != null)
                {
                    Item = await CacheStore.GetSingleByIdAsync(Id.ProviderId);
                    if (Item == null || !Item.IsTracked)
                    {
                        if (!CrossConnectivity.Current.IsConnected)
                        {
                            DependencyService.Get<IMessageToast>().LongAlert("No internet connexion");
                            return;
                        }

                        Item = await DataStore.GetItemAsync(Id.ProviderId, Id.Title);
                    }
                    else
                    {
                        Tracked = true;
                    }
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