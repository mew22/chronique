using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Chronique
{
    public partial class NewArtistePage : ContentPage
    {
        public Artiste Item { get; set; }

        public NewArtistePage()
        {
            InitializeComponent();

            Item = new Artiste("test");

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
