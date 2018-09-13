using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chronique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            img_about.Source = ImageSource.FromResource("Chronique.Images.about.png");

//            img_facebook.Source = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Facebook.png");
//            img_spotify.Source = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Spotify.png");
//            img_youtube.Source = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Youtube.png");
//            img_soundcloud.Source = ImageSource.FromResource("Chronique.Images.SocialNetwork.Blog_Soundcloud.png");

        }
    }
}
