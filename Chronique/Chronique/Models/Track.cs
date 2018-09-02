using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chronique.Models
{
    public class Track : BaseModel, INotifyPropertyChanged
    {
        private int position;
        private string name;
        private List<Artiste> peoples;

        public Track(string name, int position, List<Artiste> peoples)
        {
            this.Name = name;
            this.Position = position;
            this.Peoples = peoples;
        }

        public string Name
        {
            get => name;
            set { name = value; this.OnPropertyChanged("Name"); }
        }
        public int Position
        {
            get => position;
            set { position = value; this.OnPropertyChanged("Position"); }
        }

        public List<Artiste> Peoples
        {
            get => peoples;
            set { peoples = value; this.OnPropertyChanged("Peoples"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
