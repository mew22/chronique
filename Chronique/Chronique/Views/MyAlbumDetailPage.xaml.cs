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
    public partial class MyAlbumDetailPage : ContentPage
    {
        private MyAlbumDetailsViewModel viewModel;
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Item == null)
                viewModel.LoadItemsCommand.Execute(viewModel.Id.ProviderId);
        }

        public MyAlbumDetailPage(MyAlbumDetailsViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            BindingContext = viewModel;
        }
    }
}
