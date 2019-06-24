using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace Chronique.Models
{
    public class MyKeyValuePair : RealmObject
    {
        [PrimaryKey] public string Id { get; set; }
        [Indexed] public string ArtistId { get; set; }
        [Indexed] public string Key { get; set; }
        public string Value { get; set; }

        public MyKeyValuePair()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public MyKeyValuePair(string artistId, string key, string value)
        {
            this.Id = Guid.NewGuid().ToString();
            ArtistId = artistId;
            Key = key;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            MyKeyValuePair q = obj as MyKeyValuePair;
            return q != null && q.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}