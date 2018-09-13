using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Chronique.Models;
using Chronique.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MockDataStore))]
namespace Chronique.Services
{
    public class MockDataStore : IDataStoreImpl<Item>
    {
//        List<Item> items;

        public MockDataStore()
        {
            items = new ObservableCollection<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }
    }
}
