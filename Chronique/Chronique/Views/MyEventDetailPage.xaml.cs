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
    public partial class MyEventDetailPage : ContentPage
    {
        private MyEventDetailsViewModel viewModel;

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

        public MyEventDetailPage(MyEventDetailsViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            BindingContext = viewModel;
        }

        private async void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            await Task.Delay(2000);
        }

        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnTapRelationsList(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnTapAlbumsList(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnTapSimilarsList(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}