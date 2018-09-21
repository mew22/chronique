using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Chronique.Models;
using Chronique.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MockPlaylistStore))]
namespace Chronique.Services
{
    public class MockPlaylistStore : IDataStoreImpl<Playlist>
    {

        public MockPlaylistStore()
        {
            Random r = new Random();
            items = new ObservableCollection<Playlist>
            {
                new Playlist("Movember", "https://lachroniquemag.fr/wp-content/uploads/2017/11/Movember-640x640.png", "https://lachroniquemag.fr/movember", 
                "3 novembre 2017", "RapUS", "November pour faire plaisir à vos oreilles ! #ChroniquelyYours!", 
                    new List<Track>
                    {
                        new Track("Just The Way You Are", "myAlbum",1, "Rihanna", "ririId", "providedId"),
                        new Track("Black and Yellow", "myAlbum", 2, "wiz", "wizid", "id")
                    }),
                new Playlist("July", "https://lachroniquemag.fr/wp-content/uploads/2017/08/July-640x640.jpg","https://lachroniquemag.fr/july",
                "11 aout 2017", "Salsa", "July pour faire plaisir à vos oreilles ! #ChroniquelyYours!",
                new List<Track>
                {
                    new Track("Banlieusard", "Reel", 1, "Kery", "keryid", "id"),
                    new Track("50 pourcent", "peur echec", 2, "orel", "orelid", "id")
                }),
                new Playlist("7:77", "https://lachroniquemag.fr/wp-content/uploads/2017/07/777.jpg", "https://lachroniquemag.fr/777-june", 
                "7 juillet 2017", "Underground", "7:77 pour faire plaisir à vos oreilles ! #ChroniquelyYours!",
                    new List<Track>()),
                new Playlist("May.", "https://lachroniquemag.fr/wp-content/uploads/2017/07/19250918_10212966424696154_1485775530_n-640x640.png", "https://lachroniquemag.fr/may", 
                "1 mail 2017", "Multi", "May pour faire plaisir à vos oreilles ! #ChroniquelyYours!",
                new List<Track>
                {
                    new Track("Just The Way You Are", "myAlbum",1, "Rihanna", "ririId", "providedId"),
                    new Track("Black and Yellow", "myAlbum", 2, "wiz", "wizid", "id")
            })
            };

        }
    }

}
