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
                        Title = "Sorties"

                    };
//                    artistePage = new NavigationPage(new PeoplePage())
//                    {
//                        Title = "Artiste"
//
//                    };
                    playlistPage = new NavigationPage(new Views.PlaylistPage())
                    {
                        Title = "Playlist"

                    };
                    searchPage = new NavigationPage(new Views.SearchPage())
                    {
                        Title = "Search"
                    };
                   
                    newsPage.Icon = "ic_action_notifications_active.png";
                    sortiesPage.Icon = "ic_action_today.png";
                    playlistPage.Icon = "ic_action_audiotrack.png";
//                    artistePage.Icon = "ic_action_person.png";
                    searchPage.Icon = "ic_search.png";

                    break;
                default:
                    newsPage = new BlogsPage()
                    {
                        Title = "News"
                    };
                    sortiesPage = new CalendarPage()
                    {
                        Title = "Sorties"
                    };
//                    artistePage = new PeoplePage()
//                    {
//                        Title = "Artiste"
//                    };
                    playlistPage = new Views.PlaylistPage()
                    {
                        Title = "Playlist"

                    };
                    searchPage = new Views.SearchPage()
                    {
                        Title = "Search"
                    };

                    newsPage.Icon = "ic_action_notifications_active.png";
                    sortiesPage.Icon = "ic_action_today.png";
                    playlistPage.Icon = "ic_action_audiotrack.png";
//                    artistePage.Icon = "ic_action_person.png";
                    searchPage.Icon = "ic_search.png";
                    break;
            }

            Children.Add(newsPage);
            Children.Add(playlistPage);
            Children.Add(searchPage);
//            Children.Add(artistePage);
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
