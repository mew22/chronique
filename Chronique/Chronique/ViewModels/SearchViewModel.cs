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

    public class SearchViewModel : BaseListViewModel<GenericRequestObject, NewArtistePage, MockSearchStore>
    {
        public string query;
        public SearchViewModel()
        {
            Title = "La Chronique";
        }
        //        public override async Task ExecuteLoadItemsCommand()
        //        {
        //            if (IsBusy)
        //                return;
        //
        //            IsBusy = true;
        //
        //            try
        //            {
        //                var items = await DataStore.GetItemsAsync(true, query);
        //                Items.Clear();
        //                foreach (var item in items)
        //                {
        //                    Items.Add(item);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Debug.WriteLine(ex);
        //            }
        //            finally
        //            {
        //                IsBusy = false;
        //            }
        //        }
            }
    }
