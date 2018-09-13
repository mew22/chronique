using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chronique.Services;
using Hqub.MusicBrainz.API.Entities;
using IF.Lastfm.Core.Api;
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

        public async Task<Artiste> GetItemAsync(string id)
        {
            try
            {
                if (lastArtist != null && lastArtist.ProviderId == id)
                {
                    return await Task.FromResult(lastArtist);
                }

                else if (id != null && id != "" && CrossConnectivity.Current.IsConnected)
                    {
                        var artist = await Artist.GetAsync(id, "artist-rels", "url-rels", "event-rels", "release-rels");
                        var lastfmArtis = await lastFm.Artist.GetInfoByMbidAsync(id, "fr");
                        lastArtist = new Artiste(artist.Name, artist.SortName, "", artist.LifeSpan.Begin,
                            GetAge(artist.LifeSpan.Begin), artist.Country, artist.Type, "",
                            convertToMap(artist.Relations), artist.Disambiguation,
                            new List<string> {"toto", "tutu", "lulu"}, new List<string>{"mock", "joke", "loke"},
                            new List<string> {"suck", "on", "my", "dick"}, lastfmArtis.Content.Bio.Content, lastfmArtis.Content.MainImage.Large.AbsoluteUri, id);

                        return await Task.FromResult(lastArtist);
                    }
                

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Artiste>> GetItemsAsync(bool forceRefresh = false, string query = null)
        {
            MockArtisteStore mock = new MockArtisteStore();
            return mock.Items;
        }

        public int GetAge(string begin)
        {
            DateTime born;
            if (DateTime.TryParse(begin, out born))
            {
                int age = (DateTime.Now.Year - born.Year);
                return age;

            }

            return 0;
        }

        public List<KeyValuePair<string, string>> convertToMap(IEnumerable<Relation> rels)
        {
            List<KeyValuePair<string, string>> dico = new List<KeyValuePair<string, string>>();

            foreach (var item in rels)
            {
                if(item.Type != null && item.Url != null && item.Url.Resource != null)
                    dico.Add(new KeyValuePair<string, string>(item.Type, item.Url.Resource));
            }

            return dico;
        }
    }
}
