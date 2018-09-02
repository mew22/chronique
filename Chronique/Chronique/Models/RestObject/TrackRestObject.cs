using System.Collections.Generic;
using Newtonsoft.Json;

//using Realms;

namespace Chronique.Models.RestObject
{
    public class TrackRestObject
    {

        [JsonProperty(PropertyName = "name")]
        public string title;

        [JsonProperty(PropertyName = "artist")]
        public string artist_name;

        [JsonProperty(PropertyName = "mbid")]
        public string mbid;

        [JsonProperty(PropertyName = "image")]
        public List<Image> images;
    }
    public class TrackRestObjectList
    {

        [JsonProperty(PropertyName = "track")] public List<TrackRestObject> tracks;
    }
    public class TrackRestObjectHolder
    {

        [JsonProperty(PropertyName = "trackmatches")] public TrackRestObjectList track_list;
    }
    public class TrackRootObject
    {

        [JsonProperty(PropertyName = "results")] public TrackRestObjectHolder root;
    }
}