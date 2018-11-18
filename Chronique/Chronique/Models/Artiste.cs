using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Realms;

namespace Chronique.Models
{
    public class Artiste : RealmObject, BaseModel
    {
        public Artiste(string pseudo, string name = null, string otherName = null, string birthDate = null, int age = 0,
            string birthPlace = null, string job = null,
            string activityDates = null, List<MyKeyValuePair> relations = null, string musicKind = null,
            List<Artiste> similars = null, List<Album> projects = null,
            List<Event> upEvents = null, string description = null, string photo_uri = null, string providerId = null, bool isSelected = false)
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
            IsSelected = isSelected;
            Id = ++App.Counter;
        }

        public Artiste()
        {
//            Relations = new List<MyKeyValuePair>();
//            Similars = new List<Artiste>();
//            Projects = new List<Album>();
//            UpEvents = new List<Event>();
        }
        [Indexed]
        public string Pseudo { get; set; }

        public string Name { get; set; }

        public string OtherName { get; set; }

        public string BirthDate { get; set; }

        public int Age { get; set; }

        public string BirthPlace { get; set; }

        public string Job { get; set; }

        public string ActivityDates { get; set; }

        public IList<MyKeyValuePair> Relations { get;}

        public string MusicKind { get; set; }

        public IList<Artiste> Similars { get; }

        public IList<Album> Projects { get;}

        public IList<Event> UpEvents { get;}

        public string Description { get; set; }


        public string Photo_uri { get; set; }
        [PrimaryKey]
        public string ProviderId { get; set; }
        public bool IsSelected { get; set; }

        [Indexed]
        public bool IsTracked { get; set; }

        public int Id { get; set; }
    }
}