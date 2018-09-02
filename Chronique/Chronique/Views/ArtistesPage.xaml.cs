using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Chronique
{
    public partial class ArtistesPage : ContentPage
    {
        ArtistesViewModel viewModel;

        public ArtistesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ArtistesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Artiste;
            if (item == null)
                return;

            await Navigation.PushAsync(new ArtisteDetailPage(new ArtisteDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewArtistePage());
        }

        async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}