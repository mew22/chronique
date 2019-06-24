using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Chronique.Models;
using Realms;


namespace Chronique.Models
{
    public class GenericRequestObject : RealmObject
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

        public GenericRequestObject()
        {
        }

        public string ProviderId { get; set; }

        public string Title { get; set; }

        public string Type_Raw { get; set; }

        [Ignored]
        public DataType Type
        {
            get
            {
                Enum.TryParse(Type_Raw, out DataType type);
                return type;
            }
            set { Type_Raw = value.ToString(); }
        }

        public string Subtitle { get; set; }

        public string AdditionalInfos { get; set; }

        public string Photo_uri { get; set; }
    }
}