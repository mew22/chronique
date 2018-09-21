using System;
using System.Windows.Input;
using Chronique.Models;
using Xamarin.Forms;

namespace Chronique.ViewModels
{
    public class AboutViewModel : BaseViewModel<BaseModel>
    {
        public AboutViewModel()
        {


            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://lachroniquemag.fr/")));
            OpenSoundcloudCommand = new Command(() => Device.OpenUri(new Uri("https://soundcloud.com/lachroniquemag")));
            OpenFacebookCommand = new Command(() => Device.OpenUri(new Uri("https://www.facebook.com/lachroniquemag/")));
            OpenYoutubeCommand = new Command(() => Device.OpenUri(new Uri("https://www.youtube.com/channel/UCY12z7kBOgBScXdj9W7ZBVg")));
            OpenSpotifyCommand = new Command(() => Device.OpenUri(new Uri("http://open.spotify.com/user/lachroniquemag")));

            OpenLastFmCommand = new Command(() => Device.OpenUri(new Uri("https://www.last.fm/fr/home")));
            OpenMbCommand = new Command(() => Device.OpenUri(new Uri("https://musicbrainz.org/")));
            OpenSongkickCommand = new Command(() => Device.OpenUri(new Uri("https://www.songkick.com/home")));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenSoundcloudCommand { get; }
        public ICommand OpenFacebookCommand { get; }
        public ICommand OpenYoutubeCommand { get; }
        public ICommand OpenSpotifyCommand { get; }

        public ICommand OpenLastFmCommand { get; }
        public ICommand OpenMbCommand { get; }
        public ICommand OpenSongkickCommand { get; }
    }
}