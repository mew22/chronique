using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronique.ViewModels;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;

namespace Chronique 
{
    public class PlaylistViewModel : BaseListViewModel<Playlist, NewArtistePage, MockPlaylistStore>
    {
        #region Fields

        private Command<object> openWebCommand;
        private Command<object> readMoreCommand;
        private Command<object> twitterCommand;
        private Command<object> linkedInCommand;
        private Command<object> facebookCommand;
        private Command<object> googlePlusCommand;

        #endregion

        #region Constructor

        public PlaylistViewModel()
        {
            Title = "La Chronique";
            openWebCommand = new Command<object>(NavigateChroniqueLink);

            readMoreCommand = new Command<object>(NavigateToReadMoreContent);
            twitterCommand = new Command<object>(NavigateTwitterLink);
            linkedInCommand = new Command<object>(NavigateLinkedInLink);
            facebookCommand = new Command<object>(NavigateFacebookLink);
            googlePlusCommand = new Command<object>(NavigateGooglePlusLink);
            
        }

        #endregion

        #region Properties

        public Command<object> OpenWebCommand
        {
            get { return openWebCommand; }
            set { openWebCommand = value; }
        }
        public Command<object> ReadMoreCommand
        {
            get { return readMoreCommand; }
            set { readMoreCommand = value; }
        }

        public Command<object> TwitterCommand
        {
            get { return twitterCommand; }
            set { twitterCommand = value; }
        }

        public Command<object> LinkedInCommand
        {
            get { return linkedInCommand; }
            set { linkedInCommand = value; }
        }

        public Command<object> FacebookCommand
        {
            get { return facebookCommand; }
            set { facebookCommand = value; }
        }

        public Command<object> GooglePlusCommand
        {
            get { return googlePlusCommand; }
            set { googlePlusCommand = value; }
        }

        internal INavigation Navigation
        {
            get;
            set;
        }

        #endregion

        #region Private Methods

        private void NavigateToReadMoreContent(object obj)
        {
            Navigation.PushAsync(new PlaylistDetailPage(new PlaylistDetailViewModel(obj as Playlist)));
        }

        private void NavigateChroniqueLink(object obj)
        {
            var uri = (obj as Playlist).Playlist_link;
            Device.OpenUri(new Uri(uri));
        }
        private void NavigateTwitterLink(object obj)
        {
            var uri = (obj as Playlist).TwLink;
            Device.OpenUri(new Uri(uri));
        }

        private void NavigateLinkedInLink(object obj)
        {
            var uri = (obj as Playlist).LiLink;
            Device.OpenUri(new Uri(uri));
        }

        private void NavigateFacebookLink(object obj)
        {
            var uri = (obj as Playlist).FbLink;
            Device.OpenUri(new Uri(uri));
        }

        private void NavigateGooglePlusLink(object obj)
        {
            var uri = (obj as Playlist).GpLink;
            Device.OpenUri(new Uri(uri));
        }

        #endregion
    }
}
