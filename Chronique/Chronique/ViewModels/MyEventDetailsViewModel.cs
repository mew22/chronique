using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Chronique.Helpers;
using Chronique.Layout;
using Chronique.Models;
using Chronique.Services;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace Chronique.ViewModels
{
    [Preserve(AllMembers = true)]
    public class MyEventDetailsViewModel : BaseViewModel<Event>
    {
        private Event item;

        public Event Item
        {
            get => item;
            set
            {
                item = value;
                OnPropertyChanged("Item");
            }
        }

        //        public ICacheStore<Artiste> CacheStore => DependencyService.Get<ICacheStore<Artiste>>() ?? new RealmRepository<Artiste>();
        public ICacheStore<Event> CacheStore = new RealmRepository<Event>();

        private bool tracked = false;

        public bool Tracked
        {
            get => tracked;
            set
            {
                tracked = value;
                OnPropertyChanged("Tracked");
            }
        }

        public Command LoadItemsCommand { get; set; }

        public MyEventDetailsViewModel(Event evt = null)
        {
            Item = evt;
        }

        public void OnDisappearing()
        {
            if (!Tracked && CacheStore.GetSingleById(Item.ProviderId) != null)
                CacheStore.Delete(Item.ProviderId);
            else if (CacheStore.GetSingleById(Item.ProviderId) == null)
            {
                Item.IsTracked = true;
                CacheStore.Update(Item);
            }
            else
            {
                CacheStore.Update(Item);
                Action tracked = () => { Item.IsTracked = true; };
                CacheStore.Insert(tracked);
            }
        }

        public async void SwitchPersistedArtist(bool value)
        {
//            string providerId = null;
//
//            if (FromArtistPage != null)
//                providerId = FromArtistPage.ProviderId;
//            else
//            {
//                providerId = Id.ProviderId;
//            }
//            var tmp = CacheStore.GetSingleById(providerId);
//
//            if (value == false)
//            {
//                if (tmp != null)
//                {
//                    try
//                    {
//                        // TODO: Find a way to remove this workaround (realm.copy)
//                        //Item = CacheStore.DetachObject(Item);
//                        Item.IsTracked = false;
//                    }
//                    catch (Exception e)
//                    {
//                        Console.WriteLine("error: " + e);
//                        //TODO: show error message UI
//                        Tracked = true;
//                    }
//                }
//            }
//            else
//            {
//                try { 
//                if (tmp == null)
//                {
//                    Item.IsTracked = true;
//                }
//                }catch (Exception e)
//                {
//                    Console.WriteLine("error: " + e);
//                    //TODO: show error message UI
//                    Tracked = false;
//                }
//            }
        }

        public virtual async Task ExecuteLoadItemsCommand(string query = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Item = await CacheStore.GetSingleByIdAsync(Item.ProviderId) ?? Item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}