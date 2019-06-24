using Chronique.Models;
using Chronique.Services;

namespace Chronique.ViewModels
{
    [Preserve(AllMembers = true)]
    public class SearchViewModel : BaseListViewModel<GenericRequestObject, Views.NewArtistePage, MySearchCloudStore>
    {
        public string query;

        public SearchViewModel()
        {
            Title = "Search";
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