using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronique.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chronique.Layout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeopleRowLayout : Grid
    {
        private Artiste artiste;
        public PeopleRowLayout(Artiste artiste)
        {
            this.artiste = artiste;
            BindingContext = artiste;
            InitializeComponent();

        }
    }
}