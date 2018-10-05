using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chronique.Models
{
    public class Artiste : BaseModel, INotifyPropertyChanged
    {
        public Artiste(string pseudo, string name = null, string otherName = null, string birthDate = null, int age = 0,
            string birthPlace = null, string job = null,
            string activityDates = null, List<KeyValuePair<string, string>> relations = null, string musicKind = null,
            List<Artiste> similars = null, List<Album> projects = null,
            List<Event> upEvents = null, string description = null, string photo_uri = null, string providerId = null)
        {
            Pseudo = pseudo;
            Name = name;
            OtherName = otherName;
            BirthDate = birthDate;
            Age = age;
            BirthPlace = birthPlace;
            Job = job;
            ActivityDates = activityDates;
            Relations = relations;
            MusicKind = musicKind;
            Similars = similars;
            Projects = projects;
            UpEvents = upEvents;
            Description = description;
            Photo_uri = photo_uri;
            ProviderId = providerId;
        }

        public string Pseudo
        {
            get { return pseudo; }
            set
            {
                pseudo = value;
                this.OnPropertyChanged("Pseudo");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.OnPropertyChanged("Name");
            }
        }

        public string OtherName
        {
            get { return otherName; }
            set
            {
                otherName = value;
                this.OnPropertyChanged("OtherName");
            }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                this.OnPropertyChanged("BirthDate");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                this.OnPropertyChanged("Age");
            }
        }

        public string BirthPlace
        {
            get { return birthPlace; }
            set
            {
                birthPlace = value;
                this.OnPropertyChanged("BirthPlace");
            }
        }

        public string Job
        {
            get { return job; }
            set
            {
                job = value;
                this.OnPropertyChanged("Job");
            }
        }

        public string ActivityDates
        {
            get { return activityDates; }
            set
            {
                activityDates = value;
                this.OnPropertyChanged("ActivityDates");
            }
        }

        public List<KeyValuePair<string, string>> Relations
        {
            get { return relations; }
            set
            {
                relations = value;
                this.OnPropertyChanged("Relations");
            }
        }

        public string MusicKind
        {
            get { return musicKind; }
            set
            {
                musicKind = value;
                this.OnPropertyChanged("MusicKind");
            }
        }

        public List<Artiste> Similars
        {
            get { return similars; }
            set
            {
                similars = value;
                this.OnPropertyChanged("Similars");
            }
        }

        public List<Album> Projects
        {
            get { return projects; }
            set
            {
                projects = value;
                this.OnPropertyChanged("Projects");
            }
        }

        public List<Event> UpEvents
        {
            get { return upEvents; }
            set
            {
                upEvents = value;
                this.OnPropertyChanged("UpEvents");
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


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string pseudo;
        private string name;
        private string otherName;
        private string birthDate;
        private int age;
        private string birthPlace;
        private string job;
        private string activityDates;
        private List<KeyValuePair<string, string>> relations;
        private string musicKind;
        private List<Artiste> similars;
        private List<Album> projects;
        private List<Event> upEvents;
        private string description;
        private string photo_uri;
        private string providerId;
    }
}