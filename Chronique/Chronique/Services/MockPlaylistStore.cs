using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Chronique.Models;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(Chronique.MockPlaylistStore))]
namespace Chronique
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
                        new Track("Just The Way You Are", 1, 
                        new List<Artiste>
                        {
                            new Artiste("Eminem"), new Artiste("Rihanna")
                        }),new Track("Black and Yellow", 2,
                        new List<Artiste>
                        {
                            new Artiste("Wiz Khalifa")
                        })
                    }),
                new Playlist("July", "https://lachroniquemag.fr/wp-content/uploads/2017/08/July-640x640.jpg","https://lachroniquemag.fr/july",
                "11 aout 2017", "Salsa", "July pour faire plaisir à vos oreilles ! #ChroniquelyYours!",
                new List<Track>
                {
                    new Track("Banlieusard", 1,
                        new List<Artiste>
                        {
                            new Artiste("Kery James"), new Artiste("Omar Sy")
                        }),new Track("50 pourcent", 2,
                        new List<Artiste>
                        {
                            new Artiste("Orelsan")
                        })
                }),
                new Playlist("7:77", "https://lachroniquemag.fr/wp-content/uploads/2017/07/777.jpg", "https://lachroniquemag.fr/777-june", 
                "7 juillet 2017", "Underground", "7:77 pour faire plaisir à vos oreilles ! #ChroniquelyYours!",
                    new List<Track>()),
                new Playlist("May.", "https://lachroniquemag.fr/wp-content/uploads/2017/07/19250918_10212966424696154_1485775530_n-640x640.png", "https://lachroniquemag.fr/may", 
                "1 mail 2017", "Multi", "May pour faire plaisir à vos oreilles ! #ChroniquelyYours!",
                new List<Track>
                {
                new Track("Just The Way You Are", 1,
                new List<Artiste>
                {
                    new Artiste("Eminem"), new Artiste("Rihanna")
                }),new Track("Black and Yellow", 2,
                    new List<Artiste>
                    {
                        new Artiste("Wiz Khalifa")
                    })
            })
            };

        }
    }

}
