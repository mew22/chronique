using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Chronique.Layout;
using Chronique.ViewModels;
using Syncfusion.SfPicker.XForms;
using Xamarin.Forms;

namespace Chronique
{

    public class ArtistesViewModel : BaseListViewModel<Artiste, NewArtistePage, MockArtisteStore>  // INotifyPropertyChanged for ArtisteBaseViewModel
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
                DependencyService.Get<IMessageToast>().ShortAlert("Your have already added " + a.Pseudo + " to your list.");
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
