using System.Collections.Generic;
using Newtonsoft.Json;

//using Realms;

namespace Chronique.Models.RestObject
{
    public class AlbumRestObject
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

    public class AlbumRestObjectList
    {

        [JsonProperty(PropertyName = "album")] public List<AlbumRestObject> albums;
    }
    public class AlbumRestObjectHolder
    {

        [JsonProperty(PropertyName = "albummatches")] public AlbumRestObjectList albums_list;
    }
    public class AlbumRootObject
    {

        [JsonProperty(PropertyName = "results")] public AlbumRestObjectHolder root;
    }
}