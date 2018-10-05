using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chronique.Models;
using Chronique.Services;
using Hqub.MusicBrainz.API.Entities;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Objects;
using Plugin.Connectivity;
using Track = Chronique.Models.Track;

[assembly: Xamarin.Forms.Dependency(typeof(MyAlbumMockStore))]

namespace Chronique.Services
{
    public class MyAlbumMockStore : IDataStore<Album>
    {
        private LastfmClient lastFm;
        private Album lastAlbum;

        public MyAlbumMockStore()
        {
            lastFm = LastfmSingleton.Instance.LastFm;
        }

        public async Task<bool> AddItemAsync(Album item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Album item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Album> GetItemAsync(string id, string additionnalInfos = null)
        {
            try
            {
                if (lastAlbum != null && lastAlbum.ProviderId == id)
                {
                    return await Task.FromResult(lastAlbum);
                }

                else if (id != null && id != "" && CrossConnectivity.Current.IsConnected)
                {
                    //If mbid
                    if (id.Length == 36 && id.Contains("-"))
                    {
//                            var album = await Release.GetAsync(id, "artist-rels", "url-rels", "event-rels",
//                                "release-rels");
                        var lastfmAlbum = await lastFm.Album.GetInfoByMbidAsync(id);
                        lastAlbum = new Album(lastfmAlbum.Content.Name,
                            lastfmAlbum.Content.ReleaseDateUtc.ToString(), lastfmAlbum.Content.ArtistName,
                            lastfmAlbum.Content.ArtistName,
                            ConverterToViewObj.ConvertTracks(lastfmAlbum.Content.Tracks),
                            ConverterToViewObj.ConvertTags(lastfmAlbum.Content.TopTags),
                            lastfmAlbum.Content.Images.Large.AbsoluteUri,
                            lastfmAlbum.Content.Mbid);
                    }
                    else
                    {
                        var lastfmAlbum = await lastFm.Album.GetInfoAsync(additionnalInfos, id);
                        lastAlbum = new Album(lastfmAlbum.Content.Name,
                            lastfmAlbum.Content.ReleaseDateUtc.ToString(), lastfmAlbum.Content.ArtistName,
                            lastfmAlbum.Content.ArtistName,
                            ConverterToViewObj.ConvertTracks(lastfmAlbum.Content.Tracks),
                            ConverterToViewObj.ConvertTags(lastfmAlbum.Content.TopTags),
                            lastfmAlbum.Content.Images.Large.AbsoluteUri,
                            lastfmAlbum.Content.Mbid);
                    }

                    return await Task.FromResult(lastAlbum);
                }


                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Album>> GetItemsAsync(bool forceRefresh = false, string query = null)
        {
            throw new NotImplementedException();
        }
    }
}