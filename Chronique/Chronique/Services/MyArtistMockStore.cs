﻿using System;
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
                    //If mbid
                    if (id.Length == 36 && id.Contains("-"))
                    {
                        // Build an advanced query to search for the release.
//                            var query = new QueryParameters<Release>();
//                            query.Add("arid", id );
//                            query.Add("type", "album");
//                            query.Add("status", "official");
                        // Search for a release by title.

                        // TODO: add custom user agent in application init
                        Hqub.MusicBrainz.API.Configuration.UserAgent =
                            "LaChronique/1.0.0 (sebastien.delaherche@gmail.com)";

                        // Parallelise request to data providers
                        var artistRequest = Artist.GetAsync(id, "artist-rels", "url-rels", "event-rels",
                            "release-rels");
//                            var releasesRequest = Release.SearchAsync(query, 9);
                        var releasesRequest = Release.BrowseAsync("artist", id, 9);
                        var lastfmArtistRequest = lastFm.Artist.GetInfoByMbidAsync(id, "fr");
                        await Task.WhenAll(artistRequest, releasesRequest, lastfmArtistRequest);

                        var artist = await artistRequest;
                        var releases = await releasesRequest;
                        var lastfmArtis = await lastfmArtistRequest;

                        // Use tmpArtist until full artist data are ok
                        tmpArtist = new Artiste(artist.Name, artist.SortName, "", artist.LifeSpan.Begin,
                            ConverterToViewObj.GetAge(artist.LifeSpan.Begin), artist.Country, artist.Type, "",
                            ConverterToViewObj.ConvertRelToMap(artist.Relations), artist.Disambiguation,
                            new List<string> {"toto", "tutu", "lulu"}, null,
                            new List<Event>(), lastfmArtis.Content.Bio.Summary,
                            lastfmArtis.Content.MainImage.Large.AbsoluteUri, id);

                        // Load releases and releases img from MB parallele
                        List<Task<Release>> requestRelease = new List<Task<Release>>();
                        List<Task<HttpResponseMessage>> releaseImageUrl = new List<Task<HttpResponseMessage>>();
                        HttpClient client = new HttpClient();
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
                        lastArtist = tmpArtist;

                        return await Task.FromResult(tmpArtist);
                    }
                    else
                    {
                        //TODO: test paralelle async call
                        var syncArtist = lastFm.Artist.GetInfoAsync(id, "fr");
                        var syncAlbums = lastFm.Artist.GetTopAlbumsAsync(id);
                        await Task.WhenAll(syncArtist, syncAlbums);
                        var lastfmArtis = await syncArtist;
                        var lastfmArtisTopAlbums = await syncAlbums;

                        tmpArtist = new Artiste(lastfmArtis.Content.Name, lastfmArtis.Content.Name, "", "",
                            0, "", "", "", new List<KeyValuePair<string, string>>(), "",
                            new List<string> {"toto", "tutu", "lulu"},
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