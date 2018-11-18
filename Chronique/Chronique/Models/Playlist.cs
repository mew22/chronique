using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Realms;
using Xamarin.Forms;

namespace Chronique.Models
{
    public class Playlist : RealmObject
    {

        public Playlist(string name, string logoUrl, string playlist_link, string date, string kind,
            string shortDescription, List<Track> tracklist = null, string urlPlaySoundcloud = null,
            string urlPlaySoundgood = null, string urlPlayYoutube = null,
            string fbLink = null, string twLink = null, string gpLink = null, string liLink = null)
        {
            this.Name = name;
            this.LogoUrl = logoUrl;
            //this.LogoIcon = ImageSource.FromUri(new Uri(logoUrl));
            this.Playlist_link = playlist_link;
            this.Date = date;
            this.Kind = kind;
            this.ShortDescription = shortDescription;
            this.SoundcloudIcon = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Soundcloud.png");
            this.SoundsgoodIcon = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Soundsgood.png");
            this.YoutubeIcon = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Youtube.png");
            this.UrlPlaySoundcloud = urlPlaySoundcloud;
            this.UrlPlaySoundgood = urlPlaySoundgood;
            this.UrlPlayYoutube = urlPlayYoutube;
            this.FbLink = fbLink;
            this.TwLink = twLink;
            this.GpLink = gpLink;
            this.LiLink = liLink;
            this.Tracks = tracklist;
        }

        public Playlist()
        {
            this.SoundcloudIcon = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Soundcloud.png");
            this.SoundsgoodIcon = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Soundsgood.png");
            this.YoutubeIcon = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Youtube.png");
        }

        public IList<Track> Tracks { get;}

        [PrimaryKey]
        public string Name { get; set; }


        public string LogoUrl { get; set; }

        public string LogoIcon { get; set; }

        public string Playlist_link { get; set; }

        public string Date { get; set; }

        public string Kind { get; set; }

        public string ShortDescription { get; set; }

        [Ignored]
        public ImageSource SoundcloudIcon { get; set; }
        [Ignored]
        public ImageSource SoundsgoodIcon { get; set; }
        [Ignored]
        public ImageSource YoutubeIcon { get; set; }

        public string UrlPlaySoundcloud { get; set; }

        public string UrlPlaySoundgood { get; set; }

        public string UrlPlayYoutube { get; set; }

        public string FbLink { get; set; }

        public string TwLink { get; set; }

        public string GpLink { get; set; }

        public string LiLink { get; set; }
    }
}