using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Chronique.Models;
using Chronique.Services;
using Hqub.MusicBrainz.API;
using Hqub.MusicBrainz.API.Entities;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using Newtonsoft.Json;
using Plugin.Connectivity;

[assembly: Xamarin.Forms.Dependency(typeof(MyArtistMockStore))]

namespace Chronique.Services
{
    public class MyArtistMockStore : IDataStore<Artiste>
    {
        private LastfmClient lastFm;
        private Artiste lastArtist;

        public MyArtistMockStore()
        {
            lastFm = LastfmSingleton.Instance.LastFm;
        }

        public async Task<bool> AddItemAsync(Artiste item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Artiste item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Artiste> GetItemAsync(string id, string additionnalInfos = null)
        {
            Artiste tmpArtist = null;
            try
            {
                if (lastArtist != null && lastArtist.ProviderId == id)
                {
                    return await Task.FromResult(lastArtist);
                }
                else if (id != null && id != "" && CrossConnectivity.Current.IsConnected)
                {
                    HttpClient client = new HttpClient();
                    //If mbid
                    if (id.Length == 36 && id.Contains("-"))
                    {
                        // Build an advanced query to search for the release.
                        //                            var query = new QueryParameters<Release>();
                        //                            query.Add("arid", id );
                        //                            query.Add("type", "album");
                        //                            query.Add("status", "official");
                        // Search for a release by title.

                        // Parallelise request to data providers
                        var artistRequest = Artist.GetAsync(id, "artist-rels", "url-rels", "event-rels",
                            "release-rels");
//                        var releasesRequest = Release.BrowseAsync("artist", id, 9);
                        var lastfmArtisTopAlbumsRequest = lastFm.Artist.GetTopAlbumsAsync(additionnalInfos);
                        var lastfmArtistRequest = lastFm.Artist.GetInfoByMbidAsync(id, "fr");
                        var lastfmArtistSimilarsRequest = lastFm.Artist.GetSimilarByMbidAsync(id, false, 10);
                        var songKickUpEventRequest = client.GetAsync("https://api.songkick.com/api/3.0/artists/mbid:"
                                                                     + id + "/calendar.json?apikey=" +
                                                                     App.SONGKICK_API_KEY);
                        //                        await Task.WhenAll(artistRequest, releasesRequest, lastfmArtistRequest);
                        await Task.WhenAll(artistRequest, lastfmArtisTopAlbumsRequest, lastfmArtistRequest,
                            lastfmArtistSimilarsRequest, songKickUpEventRequest);

                        var artist = await artistRequest;
//                        var releases = await releasesRequest;
                        var lastfmArtisTopAlbums = await lastfmArtisTopAlbumsRequest;
                        var lastfmArtis = await lastfmArtistRequest;
                        var lastfmArtistSimilars = await lastfmArtistSimilarsRequest;
                        var songKickUpEvent = await songKickUpEventRequest;

                        // Use tmpArtist until full artist data are ok
                        tmpArtist = new Artiste(lastfmArtis.Content.Name, lastfmArtis.Content.Name, "",
                            artist.LifeSpan.Begin,
                            ConverterToViewObj.GetAge(artist.LifeSpan.Begin), artist.Country, artist.Type, "",
                            ConverterToViewObj.ConvertRelToMap(artist.Relations), artist.Disambiguation,
                            new List<Artiste>(), null,
                            new List<Event>(), lastfmArtis.Content.Bio.Summary,
                            lastfmArtis.Content.MainImage.Large.AbsoluteUri, id);

                        tmpArtist.Projects = ConverterToViewObj.ConvertAlbums(lastfmArtisTopAlbums.Content);
                        tmpArtist.Similars = ConverterToViewObj.ConvertArtistes(lastfmArtistSimilars.Content);

                        var songKickUpEvt = await songKickUpEvent.Content.ReadAsStringAsync();
                        tmpArtist.UpEvents = ConverterToViewObj.ConvertSkEvents(songKickUpEvt);

                        // If no album loaded with last.fm, try with Musicbrainz
                        if (tmpArtist.Projects?.Count == 0)
                        {
//                             Load releases and releases img from MB parallele
                            var releases = await Release.BrowseAsync("artist", id, 9);
                            List<Task<Release>> requestRelease = new List<Task<Release>>();
                            List<Task<HttpResponseMessage>> releaseImageUrl = new List<Task<HttpResponseMessage>>();
                            foreach (var release in releases.Items)
                            {
                                requestRelease.Add(Release.GetAsync(release.Id, "recordings", "artist-credits",
                                    "url-rels"));
                                var image_uri = new Uri("http://coverartarchive.org/release/" + release.Id);
                                releaseImageUrl.Add(client.GetAsync(image_uri));
                            }

                            var loadedReleases = await Task.WhenAll(requestRelease);
                            var releaseImages = await Task.WhenAll(releaseImageUrl);
                            List<Task<string>> imgContents = new List<Task<string>>();
                            foreach (var relImg in releaseImages)
                            {
                                var content = relImg.Content.ReadAsStringAsync();
                                imgContents.Add(content);
                            }

                            var imgs = await Task.WhenAll(imgContents);

                            // Try to parse json img response
                            List<string> urlList = new List<string>();
                            foreach (var img in imgs)
                            {
                                string url = null;
                                try
                                {
                                    dynamic json = JsonConvert.DeserializeObject(img);
                                    url = json.images[0].image;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                                urlList.Add(url);
                            }

                            tmpArtist.Projects = ConverterToViewObj.ConvertMbAlbums(loadedReleases, urlList);
                        }

                        lastArtist = tmpArtist;

                        return await Task.FromResult(tmpArtist);
                    }
                    else
                    {
                        //TODO: test paralelle async call
                        var syncArtist = lastFm.Artist.GetInfoAsync(id, "fr");
                        var syncAlbums = lastFm.Artist.GetTopAlbumsAsync(id);
                        var syncSimilars = lastFm.Artist.GetTopAlbumsAsync(id, false, 1, 10);
                        await Task.WhenAll(syncArtist, syncAlbums, syncSimilars);
                        var lastfmArtis = await syncArtist;
                        var lastfmArtisTopAlbums = await syncAlbums;
                        var lastfmArtisSimilars = await syncSimilars;

                        tmpArtist = new Artiste(lastfmArtis.Content.Name, lastfmArtis.Content.Name, "", "",
                            0, "", "", "", new List<KeyValuePair<string, string>>(), "",
                            new List<Artiste>(),
                            ConverterToViewObj.ConvertAlbums(lastfmArtisTopAlbums.Content),
                            new List<Event>(), lastfmArtis.Content.Bio.Summary,
                            lastfmArtis.Content.MainImage.Large.AbsoluteUri, id);
                        lastArtist = tmpArtist;

                        return await Task.FromResult(tmpArtist);
                    }
                }

                return await Task.FromResult(lastArtist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return await Task.FromResult(tmpArtist);
            }
        }

        public async Task<IEnumerable<Artiste>> GetItemsAsync(bool forceRefresh = false, string query = null)
        {
            MockArtisteStore mock = new MockArtisteStore();
            return mock.Items;
        }
    }
}