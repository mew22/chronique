using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Syncfusion.ListView.XForms;
using Syncfusion.SfPullToRefresh.XForms;
using Xamarin.Forms;

namespace Chronique
{
    public partial class BlogsPage : ContentPage
    {
        public BlogsPage()
        {
            Title = "La Chronique";
            InitializeComponent();
            viewModel.Navigation = Navigation;

//            transitionTypePicker.Items.Add("SlideOnTop");
//            transitionTypePicker.Items.Add("Push");

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            pullToRefresh.IsRefreshing = true;
            await Task.Delay(2000);
            //TODO: Implement access to mockdata with "await DataStore.AddItemAsync(item)"

            pullToRefresh.IsRefreshing = false;
        }

//        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (transitionTypePicker.SelectedIndex == 0)
//            {
//                pullToRefresh.RefreshContentThreshold = 0;
//                pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
//            }
//            else
//            {
//                pullToRefresh.RefreshContentThreshold = 50;
//                pullToRefresh.TransitionMode = TransitionType.Push;
//            }
//        }
        private async void NavigateToReadMoreContent(object obj)
        {
            await Navigation.PushAsync(new BlogsDetailPage(new BlogDetailViewModel(obj as BlogInfo)));
        }

        async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}