using System;
using Realms;

namespace Chronique.Models
{
    public class Event : RealmObject
    {
        public Event(string title = null, string date = null, string mainArtist = null, string mainArtistId = null,
            string description = null, string providerId = null, string location = null, string photo_uri = null,
            string type = null, string providerUri = null, bool isTracked = false)
        {
            Title = title;
            DateString = date;
            MainArtist = mainArtist;
            MainArtistId = mainArtistId;
            Type = type;
            Description = description;
            Photo_uri = photo_uri;
            ProviderId = providerId;
            ProviderUri = providerUri;
            Location = location;
            IsTracked = isTracked;
        }

        public Event()
        {
        }

        public string Title { get; set; }

        [Ignored] public DateTime Date => DateTime.Parse(DateString);


        public string DateString { get; set; }

        public string MainArtist { get; set; }
        [Indexed] public string MainArtistId { get; set; }
        [Indexed] public string Type { get; set; }

        public string Description { get; set; }

        public string Photo_uri { get; set; }

        [PrimaryKey] public string ProviderId { get; set; }

        public string ProviderUri { get; set; }
        [Indexed] public string Location { get; set; }


        public bool IsTracked { get; set; }
    }
}