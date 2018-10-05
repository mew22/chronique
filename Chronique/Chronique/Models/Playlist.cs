using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Chronique.Models
{
    public class Playlist : BaseModel, INotifyPropertyChanged
    {
        private string name;
        private string logoUrl;
        private ImageSource logoIcon;
        private string playlist_link;
        private string date;
        private string kind;
        private string shortDescription;

        private ImageSource soundcloudIcon;
        private ImageSource soundsgoodIcon;
        private ImageSource youtubeIcon;
        private string url_play_soundcloud;
        private string url_play_soundgood;
        private string url_play_youtube;

        private string fb_link;
        private string tw_link;
        private string gp_link;
        private string li_link;

        private List<Track> tracks;

        public Playlist(string name, string logoUrl, string playlist_link, string date, string kind,
            string shortDescription, List<Track> tracklist = null, string urlPlaySoundcloud = null,
            string urlPlaySoundgood = null, string urlPlayYoutube = null,
            string fbLink = null, string twLink = null, string gpLink = null, string liLink = null)
        {
            this.Name = name;
            this.LogoUrl = logoUrl;
            //this.LogoIcon = ImageSource.FromUri(new Uri(logoUrl));
            this.playlist_link = playlist_link;
            this.Date = date;
            this.Kind = kind;
            this.ShortDescription = shortDescription;
            this.SoundcloudIcon = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Soundcloud.png");
            this.SoundsgoodIcon = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Soundsgood.png");
            this.YoutubeIcon = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Youtube.png");
            this.UrlPlaySoundcloud = urlPlaySoundcloud;
            this.UrlPlaySoundgood = urlPlaySoundgood;
            this.UrlPlayYoutube = urlPlayYoutube;
//            this.BlogFacebookIcon = new EmbeddedResourceImageSource(new Uri("Chronique.Images.SocialNetwork.Blog_Facebook.png"));
//            this.BlogTwitterIcon = new EmbeddedResourceImageSource(new Uri("Chronique.Images.SocialNetwork.Blog_Twitter.png"));
//            this.BlogGooglePlusIcon = new EmbeddedResourceImageSource(new Uri("Chronique.Images.SocialNetwork.Blog_Google_Plus.png"));
//            this.BlogLinkedInIcon = new EmbeddedResourceImageSource(new Uri("Chronique.Images.SocialNetwork.Blog_LinkedIn.png"));
            this.FbLink = fbLink;
            this.TwLink = twLink;
            this.GpLink = gpLink;
            this.LiLink = liLink;
            this.Tracks = tracklist;
        }

        public List<Track> Tracks
        {
            get => tracks;
            set
            {
                tracks = value;
                this.OnPropertyChanged("Tracks");
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                this.OnPropertyChanged("Name");
            }
        }

        public string LogoUrl
        {
            get => logoUrl;
            set
            {
                logoUrl = value;
                this.OnPropertyChanged("LogoUrl");
            }
        }

        public ImageSource LogoIcon
        {
            get => logoIcon;
            set
            {
                logoIcon = value;
                this.OnPropertyChanged("LogoIcon");
            }
        }

        public string Playlist_link
        {
            get => playlist_link;
            set
            {
                playlist_link = value;
                this.OnPropertyChanged("Playlist_link");
            }
        }

        public string Date
        {
            get => date;
            set
            {
                date = value;
                this.OnPropertyChanged("Date");
            }
        }

        public string Kind
        {
            get => kind;
            set
            {
                kind = value;
                this.OnPropertyChanged("Kind");
            }
        }

        public string ShortDescription
        {
            get => shortDescription;
            set
            {
                shortDescription = value;
                this.OnPropertyChanged("ShortDescription");
            }
        }

        public ImageSource SoundcloudIcon
        {
            get => soundcloudIcon;
            set
            {
                soundcloudIcon = value;
                this.OnPropertyChanged("SoundcloudIcon");
            }
        }

        public ImageSource SoundsgoodIcon
        {
            get => soundsgoodIcon;
            set
            {
                soundsgoodIcon = value;
                this.OnPropertyChanged("SoundsgoodIcon");
            }
        }

        public ImageSource YoutubeIcon
        {
            get => youtubeIcon;
            set
            {
                youtubeIcon = value;
                this.OnPropertyChanged("YoutubeIcon");
            }
        }

        public string UrlPlaySoundcloud
        {
            get => url_play_soundcloud;
            set
            {
                url_play_soundcloud = value;
                this.OnPropertyChanged("UrlPlaySoundcloud");
            }
        }

        public string UrlPlaySoundgood
        {
            get => url_play_soundgood;
            set
            {
                url_play_soundgood = value;
                this.OnPropertyChanged("UrlPlaySoundsgood");
            }
        }

        public string UrlPlayYoutube
        {
            get => url_play_youtube;
            set
            {
                url_play_youtube = value;
                this.OnPropertyChanged("UrlPlayYoutube");
            }
        }

//        public EmbeddedResourceImageSource BlogFacebookIcon
//        {
//            get => blogFacebookIcon;
//            set { blogFacebookIcon = value; this.OnPropertyChanged("BlogFacebookIcon"); }
//        }
//
//        public EmbeddedResourceImageSource BlogTwitterIcon
//        {
//            get => blogTwitterIcon;
//            set { blogTwitterIcon = value; this.OnPropertyChanged("BlogTwitterIcon"); }
//        }
//
//        public EmbeddedResourceImageSource BlogGooglePlusIcon
//        {
//            get => blogGooglePlusIcon;
//            set { blogGooglePlusIcon = value; this.OnPropertyChanged("BlogGooglePlusIcon"); }
//        }
//
//        public EmbeddedResourceImageSource BlogLinkedInIcon
//        {
//            get => blogLinkedInIcon;
//            set { blogLinkedInIcon = value; this.OnPropertyChanged("BlogLinkedInIcon"); }
//        }

        public string FbLink
        {
            get => fb_link;
            set
            {
                fb_link = value;
                this.OnPropertyChanged("Fblink");
            }
        }

        public string TwLink
        {
            get => tw_link;
            set
            {
                tw_link = value;
                this.OnPropertyChanged("TwLink");
            }
        }

        public string GpLink
        {
            get => gp_link;
            set
            {
                gp_link = value;
                this.OnPropertyChanged("GpLink");
            }
        }

        public string LiLink
        {
            get => li_link;
            set
            {
                li_link = value;
                this.OnPropertyChanged("LiLink");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}