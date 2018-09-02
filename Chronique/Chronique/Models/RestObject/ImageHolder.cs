using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Chronique.Models.RestObject
{
    public class Image
    {
        [JsonProperty(PropertyName = "#text")]
        public string url;

        [JsonProperty(PropertyName = "size")]
        public string size;
    }
}
