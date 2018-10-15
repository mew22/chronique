using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Chronique.Helpers;
using Chronique.Models;
using Chronique.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MockArtisteStore))]

namespace Chronique.Services
{
    public class MockArtisteStore : IDataStoreImpl<Artiste>
    {
        private readonly string people_image = "Chronique.Images.People.Image";

        public MockArtisteStore()
        {
            Random r = new Random();
//            CachedImage test = new CachedImage
//            {
//                Source = new EmbeddedResourceImageSource(new Uri(people_image + r.Next(0, 28) + ".png"))
//            };
            items = new ObservableCollection<Artiste>
            {
                new Artiste("Kendrick Lamar", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",
                    new List<KeyValuePair<string, string>>(), "Hip hop",
                    new List<Artiste>(), new List<Album>(),
                    new List<Event>(), "no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Shakira", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",
                    new List<KeyValuePair<string, string>>(), "Hip hop",
                    new List<Artiste>(), new List<Album>(),
                    new List<Event>(), "no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Rihanna", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",
                    new List<KeyValuePair<string, string>>(), "Hip hop",
                    new List<Artiste>(), new List<Album>(),
                    new List<Event>(), "no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Sia", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",
                    new List<KeyValuePair<string, string>>(), "Hip hop",
                    new List<Artiste>(), new List<Album>(),
                    new List<Event>(), "no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Wiz", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",
                    new List<KeyValuePair<string, string>>(), "Hip hop",
                    new List<Artiste>(), new List<Album>(),
                    new List<Event>(), "no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Abcd", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",
                    new List<KeyValuePair<string, string>>(), "Hip hop",
                    new List<Artiste>(), new List<Album>(),
                    new List<Event>(), "no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
            };
        }

        public ObservableCollection<Artiste> Items
        {
            get { return items; }
        }
    }
}