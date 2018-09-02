using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Chronique
{
    public partial class ExtendedSplashPage : ContentPage
    {
        public ExtendedSplashPage()
        {

            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DelayedNaviagition();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (Device.RuntimePlatform != Device.iOS)
            {
                var existingPages = Navigation.NavigationStack.ToList();
                foreach (var page in existingPages)
                {
                    if (typeof(ExtendedSplashPage) == page.GetType())
                    {
                        Navigation.RemovePage(page);
                        break;
                    }

                }
            }
        }

        private async void DelayedNaviagition()
        {
            await Task.Delay(2000);

            if (Device.RuntimePlatform == Device.iOS)
            {
                await Navigation.PushModalAsync(new MainPage(), true);
            }
            else
                await Navigation.PushAsync(new MainPage(), true);
        }
    }
}
