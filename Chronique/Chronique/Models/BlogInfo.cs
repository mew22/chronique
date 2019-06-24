using Realms;

namespace Chronique.Models
{
    public class BlogInfo : RealmObject
    {
        public BlogInfo()
        {
        }

        [PrimaryKey] public string BlogTitle { get; set; }

        public string BlogCategory { get; set; }

        public string BlogAuthor { get; set; }

        public string FB_link { get; set; }

        public string TW_link { get; set; }

        public string GP_link { get; set; }

        public string LI_link { get; set; }

        public string ReadMoreContent { get; set; }
    }
}