using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chronique.Models
{
    public class Album : BaseModel, INotifyPropertyChanged
    {

        public Album(string name = null, string date = null, string mainArtist = null, string mainArtistId = null,
            List<Track> trackList = null, string description = null, string photo_uri = null, string providerId = null, string shortDescription = null)
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

        public string Name { get { return name; } set { name = value; this.OnPropertyChanged("Name"); } }
        public string Date { get { return date; } set { date = value; this.OnPropertyChanged("BirthDate"); } }
        public string MainArtist { get { return mainArtist; } set { mainArtist = value; this.OnPropertyChanged("MainArtist"); } }
        public string MainArtistId { get { return mainArtistId; } set { mainArtistId = value; this.OnPropertyChanged("MainArtistId"); } }

        public List<Track> TrackList { get { return trackList; } set { trackList = value; this.OnPropertyChanged("TrackList"); } }
        public string Description { get { return description; } set { description = value; this.OnPropertyChanged("Description"); } }
        public string Photo_uri { get { return photo_uri; } set { photo_uri = value; this.OnPropertyChanged("Photo_uri"); } }
        public string ProviderId { get { return providerId; } set { providerId = value; this.OnPropertyChanged("ProviderId"); } }
        public string ShortDescription { get { return shortDescription; } set { shortDescription = value; this.OnPropertyChanged("ShortDescription"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name;
        private string date;
        private string mainArtist;
        private string mainArtistId;
        private List<Track> trackList;
        private string description;
        private string photo_uri;
        private string providerId;
        private string shortDescription;
    }
}
