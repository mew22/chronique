using System.Diagnostics;
using System.Linq;
using Chronique.Layout;
using Chronique.Models;
using Chronique.Services;
using Xamarin.Forms;

namespace Chronique.ViewModels
{
    public class PlaylistDetailViewModel : BaseListViewModel<Artiste, Views.NewItemPage, MockArtistCloudStore>
    {
        public Playlist Item { get; set; }
        public string TracksNumber { get; set; }
        public Command<object> OpenArtistAddCommand { get; set; }

        internal INavigation Navigation { get; set; }

        public PlaylistDetailViewModel(Playlist item = null)
        {
            Title = item?.Name;
            Item = item;
            TracksNumber = Item.Tracks.Count + "";
            OpenArtistAddCommand = new Command<object>(OnAlertYesNoClicked);
        }

        async void OnAlertYesNoClicked(object obj)
        {
            if (Items.Count == 0)
                LoadItemsCommand.Execute(null);

            var answer = await App.Current.MainPage.DisplayAlert("Question?",
                "Would you like to add " + (obj as Artiste).Pseudo + " to your list ?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
            if (answer)
            {
                if (Items.Any(artiste => artiste.Pseudo.ToUpper() == (obj as Artiste).Pseudo.ToUpper()))
                {
                    Debug.WriteLine("Your have already added" + (obj as Artiste).Pseudo + " to your list.");
                    DependencyService.Get<IMessageToast>()
                        .ShortAlert("Your have already added " + (obj as Artiste).Pseudo + " to your list.");
                }
                else
                {
                    await DataStore.AddItemAsync((obj as Artiste));
                    Items.Add((obj as Artiste));
                    Debug.WriteLine("Successfully added " + (obj as Artiste).Pseudo + " to your list");
                    DependencyService.Get<IMessageToast>()
                        .ShortAlert("Successfully added " + (obj as Artiste).Pseudo + " to your list");
                }
            }
        }
    }
}