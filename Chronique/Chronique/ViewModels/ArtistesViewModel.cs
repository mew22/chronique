using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Chronique.Layout;
using Chronique.Models;
using Chronique.Services;
using Xamarin.Forms;

namespace Chronique.ViewModels
{
    public class
        ArtistesViewModel : BaseListViewModel<Artiste, Views.NewArtistePage, MyArtistCloudStore> // INotifyPropertyChanged for ArtisteBaseViewModel
    {
        private ImageSource delete;
        private string headerInfo;
        private string titleInfo;
        private bool isVisible;

        //        public ICacheStore<Artiste> CacheStore => DependencyService.Get<ICacheStore<Artiste>>() ?? new RealmRepository<Artiste>();
        public ICacheStore<Artiste> CacheStore = new RealmRepository<Artiste>();

        public override async Task ExecuteLoadItemsCommand(string query = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var loaded_items = await CacheStore.GetAsync(artiste =>  artiste.IsTracked);
                Items.Clear();
                foreach (var item in loaded_items)
                {
                    Items.Add(item);
                }
                this.OnPropertyChanged("IsEmpty");
                this.OnPropertyChanged("IsNotEmpty");
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

    public ImageSource Delete
        {
            get
            {
                return delete;
            }
            set
            {
                if (delete != value)
                {
                    delete = value;
                    OnPropertyChanged("Delete");
                }
            }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged("IsVisible");
                }
            }
        }

        public string HeaderInfo
        {
            get { return headerInfo; }
            set
            {
                if (headerInfo != value)
                {
                    headerInfo = value;
                    OnPropertyChanged("HeaderInfo");
                }
            }
        }

        public string TitleInfo
        {
            get { return titleInfo; }
            set
            {
                if (titleInfo != value)
                {
                    titleInfo = value;
                    OnPropertyChanged("TitleInfo");
                }
            }
        }
        public ArtistesViewModel()
        {
            Title = "La Chronique";
            titleInfo = "Photos";
            headerInfo = "";
            delete = ImageSource.FromResource("Chronique.Images.delete.png");
        }

        public void RemoveItem(Artiste item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
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