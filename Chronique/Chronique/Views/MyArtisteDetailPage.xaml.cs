using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Chronique.ViewModels;
using FFImageLoading.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace Chronique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyArtisteDetailPage : ContentPage
    {
        private MyArtistDetailsViewModel viewModel;
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Item == null)
                viewModel.LoadItemsCommand.Execute(viewModel.Id);
        }

        public MyArtisteDetailPage(MyArtistDetailsViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            BindingContext = viewModel;
        }

        void OnTapRelations(object sender, EventArgs args)
        {
            var img = (CachedImage)sender;
            string uri = ((UriImageSource)img.Source).Uri.AbsoluteUri;
            ICommand com;
            viewModel.OpenRelations.TryGetValue(uri, out com);
            com?.Execute(null);
        }

        void OnItemTapped(object sender, ItemTappedEventArgs tappedEventArgs)
        {
            var toto = "debug";
        }

        private async void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            listViewAlbums.AllowSwiping = true;
//            listViewFuturs.AllowSwiping = true;
            //pullToRefresh.IsRefreshing = true;
            await Task.Delay(2000);

            for (int i = 0; i < 3; i++)
            {
                //                var blogsCount = pullToRefreshViewModel.BlogsInfo.Count;
                //                var item = new ListViewBlogsInfo()
                //                {
                //                    BlogTitle = pullToRefreshViewModel.BlogsTitle[blogsTitleCount - blogsCount],
                //                    BlogAuthor = pullToRefreshViewModel.BlogsAuthors[blogsAuthorCount - blogsCount],
                //                    BlogCategory = pullToRefreshViewModel.BlogsCategory[blogsCategoryCount - blogsCount],
                //                    ReadMoreContent = pullToRefreshViewModel.BlogsReadMoreInfo[blogsReadMoreCount - blogsCount],
                //                };
                //                pullToRefreshViewModel.BlogsInfo.Insert(0, item);
            }
            //pullToRefresh.IsRefreshing = false;
        }
    }
}
