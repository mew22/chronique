using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Chronique.Services;
using FFImageLoading.Forms;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(Chronique.MockArtisteStore))]
namespace Chronique
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
                "Compton, California, U.S.", "Rapper songwriter", "2004–present",   "kendricklamar.com", "Hip hop",
                new List<string>() {"Vocal"}, new List<string>() {"Top Dawg"," Aftermath", " Interscope", "nique ta mer", "balance ton porc", "sale histoire"}, new List<string>(){"Album1", "Album2", "Album3"},
                new List<string>(){"album4", "playlist1"},"no description", RandomImageURIHelper.GetRandomImageUrl()
                /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Shakira", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",   "kendricklamar.com", "Hip hop",
                    new List<string>() {"Vocal"}, new List<string>() {"Top Dawg"," Aftermath", " Interscope"}, new List<string>{"Alb", "Alb2", "Alb3"},
                    new List<string>{"alb4", "play1"},"no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Rihanna", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",   "kendricklamar.com", "Hip hop",
                    new List<string>() {"Vocal"}, new List<string>() {"Top Dawg"," Aftermath", " Interscope"}, new List<string>{"1", "2", "3"},
                    new List<string>{"a4", "p1"},"no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Sia", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",   "kendricklamar.com", "Hip hop",
                    new List<string>() {"Vocal"}, new List<string>() {"Top Dawg"," Aftermath", " Interscope"}, new List<string>{"Album1", "Album2", "Album3"},
                    new List<string>{"album4", "playlist1"},"no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Wiz", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",   "kendricklamar.com", "Hip hop",
                    new List<string>() {"Vocal"}, new List<string>() {"Top Dawg"," Aftermath", " Interscope"}, new List<string>{"Album1", "Album2", "Album3"},
                    new List<string>{"album4", "playlist1"},"no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
                new Artiste("Abcd", "Kendrick Lamar Duckworth", "K-Dot", "June 17, 1987", 30,
                    "Compton, California, U.S.", "Rapper songwriter", "2004–present",   "kendricklamar.com", "Hip hop",
                    new List<string>() {"Vocal"}, new List<string>() {"Top Dawg"," Aftermath", " Interscope"}, new List<string>{"Album1", "Album2", "Album3"},
                    new List<string>{"album4", "playlist1"},"no description", RandomImageURIHelper.GetRandomImageUrl()
                    /*ImageSource.FromResource(people_image + r.Next(0, 28) + ".png")*/),
            };

        }
    }

}
