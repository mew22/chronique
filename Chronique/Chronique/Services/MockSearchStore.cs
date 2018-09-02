using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Chronique.Models;
using Chronique.Models.RestObject;
using Chronique.Services;
using Plugin.Connectivity;
using Refit;

[assembly: Xamarin.Forms.Dependency(typeof(Chronique.MockSearchStore))]
namespace Chronique
{
    public class MockSearchStore : IDataStoreImpl<GenericRequestObject>
    {
        //        List<Item> items;
        private static readonly string API_KEY_LAST_FM = "f8f9fc1fbe1b7f5abc8728f101b181cb";
        private ISearchAPI searchApi;
        public interface ISearchAPI
        {
            [Get("/2.0/?method=artist.search&artist={query}&api_key={api_key}&limit={limit}&format=json")]
            Task<ArtistRootObject> GetArtists(string query, string api_key, int limit);

            [Get("/2.0/?method=artist.getInfo&mbid={mbid}&api_key={api_key}&format=json")]
            Task<ArtistRootObject> GetArtistInfo(string mbid, string api_key);

            [Get("/2.0/?method=album.search&album={query}&api_key={api_key}&limit={limit}&format=json")]
            Task<AlbumRootObject> GetAlbums(string query, string api_key, int limit);

            [Get("/2.0/?method=track.search&track={query}&api_key={api_key}&limit={limit}&format=json")]
            Task<TrackRootObject> GetTracks(string query, string api_key, int limit);
        }
        public MockSearchStore()
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

            searchApi = RestService.For<ISearchAPI>("http://ws.audioscrobbler.com");
        }

        public override async Task<IEnumerable<GenericRequestObject>> GetItemsAsync(bool refresh = false, string query = null)
        {
            try
            {
                if (query != null && query != "" && CrossConnectivity.Current.IsConnected)
                {
                    items.Clear();
                    var artists = await searchApi.GetArtists(query, API_KEY_LAST_FM, 10);
                    foreach (var item in artists.root.artist_list.artists)
                    {
                        var id = item.mbid == null ? Guid.NewGuid().ToString() : item.mbid;
                        items.Add(new GenericRequestObject(id, item.pseudo, "", "", DataType.Artiste,
                            item.images.Last().url));
                    }

                    var albums = await searchApi.GetAlbums(query, API_KEY_LAST_FM, 10);
                    foreach (var item in albums.root.albums_list.albums)
                    {
                        var id = item.mbid == null ? Guid.NewGuid().ToString() : item.mbid;
                        items.Add(new GenericRequestObject(id, item.title, item.artist_name, "", DataType.Album,
                            item.images.Last().url));
                    }

                    var tracks = await searchApi.GetTracks(query, API_KEY_LAST_FM, 10);
                    foreach (var item in tracks.root.track_list.tracks)
                    {
                        var id = item.mbid == null ? Guid.NewGuid().ToString() : item.mbid;
                        items.Add(new GenericRequestObject(id, item.title, item.artist_name, "", DataType.Track,
                            item.images.Last().url));
                    }
                }
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.Message);
            }

            return await Task.FromResult(items);
        }
    }
}
