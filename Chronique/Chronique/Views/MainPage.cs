using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chronique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page artistePage, sortiesPage, newsPage, searchPage, playlistPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    newsPage = new NavigationPage(new BlogsPage())
                    {
                        Title = "News"
                    };
                    sortiesPage = new NavigationPage(new CalendarPage())
                    {
                        Title = "Upcoming"
                    };
                    artistePage = new NavigationPage(new PeoplePage())
                    {
                        Title = "Tracking"
                    };
                    playlistPage = new NavigationPage(new PlaylistPage())
                    {
                        Title = "Playlists"
                    };
                    searchPage = new NavigationPage(new SearchPage())
                    {
                        Title = "Search"
                    };

                    newsPage.Icon = "ic_action_notifications_active.png";
                    sortiesPage.Icon = "ic_action_today.png";
                    playlistPage.Icon = "ic_action_audiotrack.png";
                    artistePage.Icon = "ic_action_person.png";
                    searchPage.Icon = "ic_search.png";

                    break;
                default:
                    newsPage = new BlogsPage()
                    {
                        Title = "News"
                    };
                    sortiesPage = new CalendarPage()
                    {
                        Title = "Events"
                    };
                    artistePage = new PeoplePage()
                    {
                        Title = "Tracking"
                    };
                    playlistPage = new PlaylistPage()
                    {
                        Title = "Playlists"
                    };
                    searchPage = new SearchPage()
                    {
                        Title = "Search"
                    };

                    newsPage.Icon = "ic_action_notifications_active.png";
                    sortiesPage.Icon = "ic_action_today.png";
                    playlistPage.Icon = "ic_action_audiotrack.png";
                    artistePage.Icon = "ic_action_person.png";
                    searchPage.Icon = "ic_search.png";
                    break;
            }

            Children.Add(newsPage);
            Children.Add(playlistPage);
//            Children.Add(searchPage);
            Children.Add(artistePage);
            Children.Add(sortiesPage);


            //Title = Children[0].Title;
            Title = "La Chronique";
            NavigationPage.SetHasNavigationBar(this, true);
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            //Title = CurrentPage?.Title ?? string.Empty;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}