using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace Chronique.Models
{
    public class Track : RealmObject
    {
  
        public Track(string name = null, string albumName = null, int? position = 0, string artistName = null,
            string artistId = null, string providerId = null)
        {
            this.Name = name;
            this.AlbumName = albumName;
            this.Position = position;
            this.ArtistName = artistName;
            this.ArtistId = artistId;
            this.ProviderId = providerId;
        }

        public Track()
        {

        }
        [Indexed]
        public string AlbumName { get; set; }

        public string ArtistName { get; set; }
    

        public int? Position { get; set; }
        [Indexed]
        public string ArtistId { get; set; }

        [PrimaryKey]
        public string ProviderId { get; set; }

        public string Name { get; set; }
    }
}