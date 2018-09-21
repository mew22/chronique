using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chronique.Models
{
    public class Track : BaseModel, INotifyPropertyChanged
    {
        private int? position;
        private string name;
        private string albumName;
        private string artistName;
        private string artistId;
        private string providerId;

        public Track(string name = null, string albumName = null, int? position = 0, string artistName = null, string artistId = null, string providerId = null)
        {
            this.Name = name;
            this.AlbumName = albumName;
            this.Position = position;
            this.ArtistName = artistName;
            this.ArtistId = artistId;
            this.ProviderId = providerId;
        }

        public string AlbumName
        {
            get => albumName;
            set { albumName = value; this.OnPropertyChanged("AlbumName"); }
        }
        public string ArtistName
        {
            get => artistName;
            set { artistName = value; this.OnPropertyChanged("ArtistName"); }
        }
        public int? Position
        {
            get => position;
            set { position = value; this.OnPropertyChanged("Position"); }
        }

        public string ArtistId
        {
            get => artistId;
            set { artistId = value; this.OnPropertyChanged("ArtistId"); }
        }
        public string ProviderId
        {
            get => providerId;
            set { providerId = value; this.OnPropertyChanged("ProviderId"); }
        }
        public string Name
        {
            get => name;
            set { name = value; this.OnPropertyChanged("Name"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
