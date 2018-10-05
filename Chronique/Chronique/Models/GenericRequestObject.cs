using System.ComponentModel;
using System.Runtime.CompilerServices;
using Chronique.Models;


namespace Chronique.Models
{
    public class GenericRequestObject : BaseModel, INotifyPropertyChanged
    {
        public GenericRequestObject(string providerId, string title, string subtitle = null,
            string additionalInfos = null, DataType type = DataType.Artiste, string photo_uri = null)
        {
            ProviderId = providerId;
            Title = title;
            Subtitle = subtitle;
            AdditionalInfos = additionalInfos;
            Type = type;
            Photo_uri = photo_uri;
        }

        public string ProviderId
        {
            get { return providerId; }
            set
            {
                providerId = value;
                this.OnPropertyChanged("ProviderId");
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.OnPropertyChanged("Title");
            }
        }

        public DataType Type
        {
            get { return type; }
            set
            {
                type = value;
                this.OnPropertyChanged("Type");
            }
        }

        public string Subtitle
        {
            get { return subtitle; }
            set
            {
                subtitle = value;
                this.OnPropertyChanged("Subtitle");
            }
        }

        public string AdditionalInfos
        {
            get { return additionalInfos; }
            set
            {
                additionalInfos = value;
                this.OnPropertyChanged("AdditionalInfos");
            }
        }

        public string Photo_uri
        {
            get { return photo_uri; }
            set
            {
                photo_uri = value;
                this.OnPropertyChanged("Photo_uri");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string providerId;
        private string title;
        private string subtitle;
        private string additionalInfos;
        private DataType type;
        private string photo_uri;
    }
}