using System;
using System.Threading.Tasks;
using Chronique.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chronique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtisteDetailPage : ContentPage
    {
        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.


        public ArtisteDetailPage(ArtisteDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
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