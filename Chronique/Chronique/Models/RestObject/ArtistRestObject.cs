using System.Collections.Generic;
using Newtonsoft.Json;

//using Realms;

namespace Chronique.Models.RestObject
{
    public class ArtistRestObject
    {

        [JsonProperty(PropertyName = "name")]
        public string pseudo;

        [JsonProperty(PropertyName = "mbid")]
        public string mbid;

        [JsonProperty(PropertyName = "image")]
        public List<Image> images;
    }
    public class ArtistRestObjectList
    {

        [JsonProperty(PropertyName = "artist")] public List<ArtistRestObject> artists;
    }

    public class ArtistRestObjectHolder
    {

        [JsonProperty(PropertyName = "artistmatches")] public ArtistRestObjectList artist_list;
    }

    public class ArtistRootObject
    {

        [JsonProperty(PropertyName = "results")] public ArtistRestObjectHolder root;
    }
}