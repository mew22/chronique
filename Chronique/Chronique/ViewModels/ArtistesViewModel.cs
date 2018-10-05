using System.Diagnostics;
using System.Linq;
using Chronique.Layout;
using Chronique.Models;
using Chronique.Services;
using Xamarin.Forms;

namespace Chronique.ViewModels
{
    public class
        ArtistesViewModel : BaseListViewModel<Artiste, Views.NewArtistePage, MockArtisteStore
        > // INotifyPropertyChanged for ArtisteBaseViewModel
    {
        public ArtistesViewModel()
        {
            Title = "La Chronique";
        }


        public async void PickerValidated(Artiste a)
        {
            if (Items.Any(artiste => artiste.Pseudo.ToUpper() == a.Pseudo.ToUpper()))
            {
                Debug.WriteLine("Your have already added" + a.Pseudo + " to your list.");
                DependencyService.Get<IMessageToast>()
                    .ShortAlert("Your have already added " + a.Pseudo + " to your list.");
            }
            else
            {
                await DataStore.AddItemAsync(a);
                Items.Add(a);
                Debug.WriteLine("Successfully added " + a.Pseudo + " to your list");
                LoadItemsCommand.Execute(null);
                DependencyService.Get<IMessageToast>().ShortAlert("Successfully added " + a.Pseudo + " to your list");
            }
        }
    }
}