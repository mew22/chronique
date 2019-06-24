using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Chronique.Models;
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
                viewModel.LoadItemsCommand.Execute(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.OnDisappearing();
        }

        public MyArtisteDetailPage(MyArtistDetailsViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            BindingContext = viewModel;
        }

        //        void OnTapRelations(object sender, EventArgs args)
        //        {
        //            var img = (CachedImage)sender;
        //            string uri = ((EmbeddedResourceImageSource)img.Source).Uri.AbsoluteUri;
        //            var convert = uri.Split(new[] { "/?" }, StringSplitOptions.None);
        //            ICommand com = null;
        //            viewModel.OpenRelations.TryGetValue(convert[0], out com);
        //            com?.Execute(null);
        //        }

        async void OnTapAlbumsList(object sender, ItemTappedEventArgs args)
        {
            if (!(args.ItemData is Album item) || item.ProviderId == null || item.ProviderId == "")
                return;

            await Navigation.PushAsync(new MyAlbumDetailPage(new MyAlbumDetailsViewModel(item)));

            // Manually deselect item
            listViewAlbums.SelectedItem = null;
        }

        async void OnTapSimilarsList(object sender, ItemTappedEventArgs args)
        {
            if (!(args.ItemData is Artiste item) || item.ProviderId == null || item.ProviderId == "")
                return;

            await Navigation.PushAsync(new MyArtisteDetailPage(new MyArtistDetailsViewModel(item)));

            // Manually deselect item
            listViewSimilars.SelectedItem = null;
        }

        async void OnTapRelationsList(object sender, ItemTappedEventArgs tappedEventArgs)
        {
            string uri = (string) tappedEventArgs.ItemData;
            ICommand com = null;
            viewModel.OpenRelations.TryGetValue(uri, out com);
            com?.Execute(null);
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

        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            viewModel.SwitchPersistedArtist(e.Value);
        }
    }
}