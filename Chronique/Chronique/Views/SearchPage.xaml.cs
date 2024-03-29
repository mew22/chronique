﻿using System;
using System.Collections.Specialized;
using Chronique.Models;
using Chronique.ViewModels;
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chronique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

//            if (viewModel.Items.Count == 0)
//                viewModel.LoadItemsCommand.Execute(null);
        }

        public SearchPage()
        {
            //            Title = "La Chronique";
            Title = "Search";
            InitializeComponent();

            //TODO:Unlock to test
            listView.DataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "Title",
                Direction = ListSortDirection.Ascending
            });
            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "Type",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as GenericRequestObject);
                    return item.Type.ToString();
                },
            });

            listView.DataSource.FilterChanged += DataSource_FilterChanged;
        }

        #region FilterBar event

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (listView.DataSource != null)
            {
                this.listView.DataSource.Filter = FilterContacts;
                this.listView.DataSource.RefreshFilter();
            }
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            searchBar = (sender as SearchBar);
//            viewModel.query = searchBar.Text.ToLower();
            viewModel.LoadItemsCommand.Execute(searchBar.Text.ToLower());
            listView.DataSource.Filter = null;
            listView.DataSource.RefreshFilter();
        }

        private bool FilterContacts(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            //TODO: Look at clearing filter
//            listView.DataSource.Filter = null;
//            listView.DataSource.RefreshFilter();
            var contacts = obj as GenericRequestObject;
            if (contacts.Title.ToLower().Contains(searchBar.Text.ToLower())
                || contacts.Title.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else
                return false;
        }

        #endregion

        #region PullToRefresh Event

        private async void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            pullToRefresh.IsRefreshing = true;
            viewModel.LoadItemsCommand.Execute(null);

            for (int i = 0; i < 3; i++)
            {
//                var blogsCount = pullToRefreshViewModel.BlogsInfo.Count;
//                var item = new ListViewBlogsInfo()
//                {
//                    BlogTitle = pullToRefreshViewModel.BlogsTitle[blogsTitleCount - blogsCount],
//                    BlogAuthor = pullToRefreshViewModel.BlogsAuthors[blogsAuthorCount - blogsCount],
//                    BlogCategory = pullToRefreshViewModel.BlogsCategory[blogsCategoryCount - blogsCount],
//                    ReadMoreContent = pullToRefreshViewModel.BlogsReadMoreInfo[blogsReadMoreCount - blogsCount],
//                };
//                pullToRefreshViewModel.BlogsInfo.Insert(0, item);
            }

            pullToRefresh.IsRefreshing = false;
        }

        private async void PullToRefresh_Refreshed(object sender, EventArgs args)
        {
        }

        private async void PullToRefresh_Pulling(object sender, EventArgs args)
        {
        }

        #endregion

        #region List Event

        private void ListView_GroupExpanding(object sender, GroupExpandCollapseChangingEventArgs e)
        {
//            if (e.Groups[0] == listView.DataSource.Groups[0])
//                e.Cancel = true;
        }

        private void ListView_GroupCollapsing(object sender, GroupExpandCollapseChangingEventArgs e)
        {
//            if (e.Groups[0] == listView.DataSource.Groups[0])
//                e.Cancel = true;
        }

        async void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            //            if (e.ItemData == viewModel.InboxInfo[0])
            //                viewModel.InboxInfo.Remove(e.ItemData as ListViewInboxInfo);
            if (!(e.ItemData is GenericRequestObject item) || item.ProviderId == null || item.ProviderId == "")
                return;
            switch (item.Type)
            {
                case DataType.Artiste:
                    await Navigation.PushAsync(new MyArtisteDetailPage(new MyArtistDetailsViewModel(item)));
                    break;
                case DataType.Album:
                    await Navigation.PushAsync(new MyAlbumDetailPage(new MyAlbumDetailsViewModel(item)));
                    break;
            }


            // Manually deselect item
            listView.SelectedItem = null;
        }

        private void ListView_ItemHolding(object sender, ItemHoldingEventArgs e)
        {
//            if (e.ItemData == viewModel.InboxInfo[3])
//                viewModel.InboxInfo.Remove(e.ItemData as ListViewInboxInfo);
        }

        private void ListView_ItemDoubleTapped(object sender, ItemDoubleTappedEventArgs e)
        {
//            var listViewInboxInfo = new ListViewInboxInfo();
//            listViewInboxInfo.Title = "Bryce Thomas";
//            listViewInboxInfo.Subject = "Congratulations on the move!";
//            viewModel.InboxInfo.Add(listViewInboxInfo);
        }

        private void DataSource_FilterChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //            //Contacts is model class 
            //            ObservableCollection<Artiste> artiste = new ObservableCollection<Artiste>();
            //            // Get the filtered items
            //            var items = (sender as DataSource).DisplayItems;
            //            foreach (var item in items)
            //                artiste.Add(item as Artiste);

//            listView.DataSource.SortDescriptors.Add(new SortDescriptor
//            {
//                PropertyName = "Pseudo",
//                Direction = ListSortDirection.Ascending
//            });
//            listView.RefreshView();
        }

        #endregion

        #region Menu

        async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        #endregion
    }
}