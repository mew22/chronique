using System.Collections.Generic;
using Newtonsoft.Json;

//using Realms;

namespace Chronique.Models
{
    public class ArtisteObject : IRealmObject //, RealmObject
    {
        [JsonProperty("name")] private string pseudo;

        [JsonProperty("mbid")] private string mbid;

        private string name;
        private string otherName;
        private string birthDate;
        private int age;
        private string birthPlace;
        private string job;
        private string activityDates;
        private string webSite;
        private string musicKind;
        private List<string> instruments;
        private List<string> labels;
        private List<string> projects;
        private List<string> futursProject;
        private string description;

        [JsonProperty("image")] private string photo_uri;
        public string Id { get; set; }
    }
}