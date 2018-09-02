using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Chronique
{
    public partial class PlaylistDetailPage : ContentPage
    {


        public PlaylistDetailPage(PlaylistDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
