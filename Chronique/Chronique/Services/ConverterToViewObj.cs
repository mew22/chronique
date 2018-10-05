using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chronique.Models;
using Hqub.MusicBrainz.API.Entities;
using IF.Lastfm.Core.Objects;
using Newtonsoft.Json;
using Track = Chronique.Models.Track;

namespace Chronique.Services
{
    public static class ConverterToViewObj
    {
        public static int GetAge(string begin)
        {
            DateTime born;
            if (DateTime.TryParse(begin, out born))
            {
                int age = (DateTime.Now.Year - born.Year);
                return age;
            }

            return 0;
        }

        public static List<KeyValuePair<string, string>> ConvertRelToMap(IEnumerable<Relation> rels)
        {
            List<KeyValuePair<string, string>> dico = new List<KeyValuePair<string, string>>();

            foreach (var item in rels)
            {
                if (item.Type != null && item.Url != null && item.Url.Resource != null)
                    dico.Add(new KeyValuePair<string, string>(item.Type, item.Url.Resource));
            }

            return dico;
        }

        public static List<Album> ConvertAlbums(IEnumerable<LastAlbum> albums)
        {
            List<Album> albs = new List<Album>();
            foreach (var al in albums)
            {
                if (!string.IsNullOrEmpty(al.Name) && al.Name != "(null)")
                {
                    var image = al?.Images?.Large?.AbsoluteUri ?? "resource://Chronique.Images.PlaceHolder.error.png";

                    albs.Add(new Album(al.Name, al.ReleaseDateUtc.ToString(), al.ArtistName, al.ArtistName,
                        ConvertTracks(al.Tracks), ConvertTags(al.TopTags), image,
                        al.Mbid ?? al.Name));
                }
            }

            return albs;
        }

        public static List<Album> ConvertMbAlbums(Release[] albums, List<string> images = null)
        {
            List<Album> albs = new List<Album>();
            for (int i = 0; i < albums.Length; ++i)
            {
                var artist = albums[i].Credits.First();
                var medium = albums[i].Media.First();
                var image = "resource://Chronique.Images.PlaceHolder.error.png";
                if (images != null && images[i] != null && i < images.Count)
                    image = images[i];
                albs.Add(new Album(albums[i].Title, albums[i].Date, artist.Artist.Name, artist.Artist.Id,
                    ConvertMbTracks(albums[i].Title, medium.Tracks), ConvertMbLabel(albums[i].Labels), image,
                    albums[i].Id));
            }

            return albs;
        }

        public static List<Track> ConvertMbTracks(string releaseName,
            IEnumerable<Hqub.MusicBrainz.API.Entities.Track> tracks)
        {
            List<Track> convertedTracks = new List<Track>();
            foreach (var track in tracks)
            {
                var artist = track.Recording.Credits.First();
                convertedTracks.Add(new Track(track.Recording.Title, releaseName, track.Position, artist.Artist.Name,
                    artist.Artist.Id, track.Id));
            }

            return convertedTracks;
        }

        public static List<Track> ConvertTracks(IEnumerable<LastTrack> tracks)
        {
            List<Track> convertedTracks = new List<Track>();
            foreach (var track in tracks)
            {
                convertedTracks.Add(new Track(track.Name, track.AlbumName, track.Rank, track.ArtistName,
                    track.ArtistMbid, track.Mbid ?? track.Id));
            }

            return convertedTracks;
        }

        public static string ConvertTags(IEnumerable<LastTag> tags)
        {
            if (tags == null)
                return "";
            StringBuilder strBuilder = new StringBuilder();
            foreach (var tag in tags)
            {
                strBuilder.Append(tag.Name + ", ");
            }

            return strBuilder.ToString();
        }

        public static string ConvertMbLabel(IEnumerable<LabelInfo> labels)
        {
            if (labels == null)
                return "";
            StringBuilder strBuilder = new StringBuilder();
            foreach (var label in labels)
            {
                strBuilder.Append(label.Label.Name + ", ");
            }

            return strBuilder.ToString();
        }

        public static List<Artiste> ConvertArtistes(IEnumerable<LastArtist> artists)
        {
            List<Artiste> converted = new List<Artiste>();
            foreach (var ar in artists)
            {
                Artiste a = new Artiste(ar.Name);
                a.Photo_uri = ar.MainImage.Large.AbsoluteUri;
                a.ProviderId = ar.Mbid ?? ar.Name;
                converted.Add(a);
            }

            return converted;
        }

        public static List<Event> ConvertSkEvents(string data)
        {
            List<Event> upEvents = new List<Event>();

            try
            {
                dynamic json = JsonConvert.DeserializeObject(data);
                foreach (var evt in json.resultsPage.results["event"])
                {
                    try
                    {
                        Event upEvent = new Event();
                        upEvent.Title = evt.displayName;
                        upEvent.Type = evt.type;
                        upEvent.DateString = evt.start.date;
                        upEvent.Location = evt.location.city;
                        upEvent.ProviderUri = evt.uri;

                        upEvents.Add(upEvent);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("error parsing json: " + e);
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error parsing json: " + e);
            }

            return upEvents;
        }
    }
}