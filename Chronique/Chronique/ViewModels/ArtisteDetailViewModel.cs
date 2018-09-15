using Chronique.Models;

namespace Chronique.ViewModels
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
