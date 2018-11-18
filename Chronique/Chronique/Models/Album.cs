using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Realms;

namespace Chronique.Models
{
    public class Album : RealmObject
    {
        public Album(string name = null, string date = null, string mainArtist = null, string mainArtistId = null,
            List<Track> trackList = null, string description = null, string photo_uri = null, string providerId = null,
            string shortDescription = null)
        {
            Name = name;
            Date = date;
            MainArtist = mainArtist;
            MainArtistId = mainArtistId;
            TrackList = trackList;
            Description = description;
            Photo_uri = photo_uri;
            ProviderId = providerId;
            ShortDescription = shortDescription;
        }

        public Album()
        {
            TrackList = new List<Track>();
        }
        [Indexed]
        public string Name { get; set; }
        [Indexed]
        public string Date { get; set; }
       
        public string MainArtist { get; set; }
        [Indexed]
        public string MainArtistId { get; set; }

        public IList<Track> TrackList { get; }

        public string Description { get; set; }

        public string Photo_uri { get; set; }
        [PrimaryKey]
        public string ProviderId { get; set; }

        public string ShortDescription { get; set; }
    }
}