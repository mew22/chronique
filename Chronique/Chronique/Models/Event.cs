using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Syncfusion.SfCalendar.XForms;

namespace Chronique.Models
{
    public class Event : BaseModel, INotifyPropertyChanged
    {
        public Event(string title = null, string date = null, string mainArtist = null, string mainArtistId = null,
            string description = null, string providerId = null, string location = null, string photo_uri = null,
            string type = null, string providerUri = null)
        {
            Title = title;
            try
            {
                Date = DateTime.Parse(date);
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e);
                Date = DateTime.Today;
            }

            MainArtist = mainArtist;
            MainArtistId = mainArtistId;
            Type = type;
            Description = description;
            Photo_uri = photo_uri;
            ProviderId = providerId;
            ProviderUri = providerUri;
            Location = location;
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

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                this.OnPropertyChanged("Date");
            }
        }

        public string DateString
        {
            get { return date.ToString("dd MMMM, YYYY hh:mm:tt"); }
            set
            {
                DateTime.TryParse(value, out date);
                this.OnPropertyChanged("Date");
            }
        }

        public string MainArtist
        {
            get { return mainArtist; }
            set
            {
                mainArtist = value;
                this.OnPropertyChanged("MainArtist");
            }
        }

        public string MainArtistId
        {
            get { return mainArtistId; }
            set
            {
                mainArtistId = value;
                this.OnPropertyChanged("MainArtistId");
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                this.OnPropertyChanged("Type");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                this.OnPropertyChanged("Description");
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

        public string ProviderId
        {
            get { return providerId; }
            set
            {
                providerId = value;
                this.OnPropertyChanged("ProviderId");
            }
        }

        public string ProviderUri
        {
            get { return providerUri; }
            set
            {
                providerUri = value;
                this.OnPropertyChanged("ProviderUri");
            }
        }

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                this.OnPropertyChanged("Location");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string title;
        private DateTime date;
        private string mainArtist;
        private string mainArtistId;
        private string type;
        private string description;
        private string photo_uri;
        private string providerId;
        private string providerUri;
        private string location;
    }
}