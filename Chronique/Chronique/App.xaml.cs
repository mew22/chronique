using System;


using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Device = Xamarin.Forms.Device;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Chronique
{
    public partial class App : Application
    {
        public static readonly string SONGKICK_API_KEY = "AZjkNivxIbJtdy2l";
        public App()
        {
            Hqub.MusicBrainz.API.Configuration.UserAgent =
                "LaChronique/1.0.0 (sebastien.delaherche@gmail.com)";
            InitializeComponent();

//            if (Device.RuntimePlatform == Device.iOS)
//                MainPage = new MainPage();
//            else
//                MainPage = new NavigationPage(new MainPage());

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new NavigationPage(new Views.ExtendedSplashPage());
            else
                MainPage = new NavigationPage(new Views.ExtendedSplashPage());
        }


        protected override void OnStart()
        {
            base.OnStart();
            AppCenter.Start("ios=9d33b664-e5c5-4237-bb25-afbc50024b6c;" +
                            "android=d1fe6934-15c6-4ec1-88fb-73357451198e;",
                typeof(Analytics), typeof(Crashes), typeof(Distribute));
            Distribute.SetEnabledAsync(true);
        }
    }
}