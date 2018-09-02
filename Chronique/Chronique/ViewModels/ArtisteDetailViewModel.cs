using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Chronique.Models;

namespace Chronique
{
    public class ArtisteDetailViewModel : BaseViewModel<Artiste>
    {
        public Artiste Item { get; set; }
        public ArtisteDetailViewModel(Artiste item = null)
        {
            Title = item?.Pseudo;
            Item = item;
        }

    }
}
