using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Chronique.Models;
using Chronique.Services;
using IF.Lastfm.Core.Api;
using Plugin.Connectivity;

[assembly: Xamarin.Forms.Dependency(typeof(MySearchCloudStore))]

namespace Chronique.Services
{
    public class MySearchCloudStore : ICloudStoreImpl<GenericRequestObject>
    {
        //        List<Item> items;
//        private ISearchAPI searchApi;
//        public interface ISearchAPI
//        {
//            [Get("/2.0/?method=artist.search&artist={query}&api_key={api_key}&limit={limit}&format=json")]
//            Task<ArtistRootObject> GetArtists(string query, string api_key, int limit);
//
//            [Get("/2.0/?method=artist.getInfo&mbid={mbid}&api_key={api_key}&format=json")]
//            Task<ArtistRootObject> GetArtistInfo(string mbid, string api_key);
//
//            [Get("/2.0/?method=album.search&album={query}&api_key={api_key}&limit={limit}&format=json")]
//            Task<AlbumRootObject> GetAlbums(string query, string api_key, int limit);
//
//            [Get("/2.0/?method=track.search&track={query}&api_key={api_key}&limit={limit}&format=json")]
//            Task<TrackRootObject> GetTracks(string query, string api_key, int limit);
//        }
        private LastfmClient lastFm;

        public MySearchCloudStore()
        {
            items = new ObservableCollection<GenericRequestObject>();

            //TODO: Mocking data
            //            var mockItems = new List<GenericRequestObject>
            //            {
            //                new GenericRequestObject (Guid.NewGuid().ToString(), "Rihanna", "Chanteuse, parolière, actrice, designer, mannequin", "Pop, RnB, hip-hop, reggae, dance", DataType.Artiste, "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Rihanna_concert_in_Washington_DC_%282%29.jpg/1280px-Rihanna_concert_in_Washington_DC_%282%29.jpg"),
            //                new GenericRequestObject (Guid.NewGuid().ToString(), "Shakira", "Chanteuse, auteure-compositrice-interprète, productrice, danseuse, actrice" , "Latino, pop, rock, dance", DataType.Artiste, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Shakira_2014.jpg/498px-Shakira_2014.jpg"),
            //                new GenericRequestObject (Guid.NewGuid().ToString(), "Faded", "Alan Walker", "Electro house", DataType.Track, "https://upload.wikimedia.org/wikipedia/commons/3/3e/Alan_Walker-_Logo.png"),
            //                new GenericRequestObject (Guid.NewGuid().ToString(), "El Dorado", "Shakira", "26 mai 2017", DataType.Album, "https://upload.wikimedia.org/wikipedia/commons/3/3d/El_Dorado_Shakira.png")
            //            };
            //
            //            foreach (var item in mockItems)
            //            {
            //                items.Add(item);
            //            }

            //TODO: logging error
//            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri("http://ws.audioscrobbler.com")};
//            searchApi = RestService.For<ISearchAPI>(httpClient);

//            searchApi = RestService.For<ISearchAPI>("http://ws.audioscrobbler.com");
            lastFm = LastfmSingleton.Instance.LastFm;
        }

        public override async Task<IEnumerable<GenericRequestObject>> GetItemsAsync(bool refresh = false,
            string query = null)
        {
            try
            {
                if (query != null && query != "" && CrossConnectivity.Current.IsConnected)
                {
                    items.Clear();
                    var artists = await lastFm.Artist.SearchAsync(query, 1, 10);
                    foreach (var item in artists)
                    {
                        var id = item.Mbid == "" ? item.Name : item.Mbid;
                        items.Add(new GenericRequestObject(id, item.Name, "", "", DataType.Artiste,
                            item.MainImage.Large.AbsoluteUri));
                    }

                    var albums = await lastFm.Album.SearchAsync(query, 1, 10);
                    foreach (var item in albums)
                    {
                        var id = item.Mbid == "" ? item.Name : item.Mbid;
                        items.Add(new GenericRequestObject(id, item.Name, item.ArtistName, "", DataType.Album,
                            item.Images.Large.AbsoluteUri));
                    }

                    var tracks = await lastFm.Track.SearchAsync(query, 1, 10);
                    foreach (var item in tracks)
                    {
                        var id = item.Mbid == "" ? item.Name : item.Mbid;
                        items.Add(new GenericRequestObject(id, item.Name, item.ArtistName, "", DataType.Track,
                            item.Images.Large.AbsoluteUri));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //            catch (ApiException e)
            //            {
            //                Console.WriteLine(e.Message);
            //            }

            return await Task.FromResult(items);
        }
    }
}