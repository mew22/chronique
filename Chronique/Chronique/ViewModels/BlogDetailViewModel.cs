using System;

namespace Chronique
{
    public class BlogDetailViewModel : BaseViewModel<BlogInfo>
    {
        public BlogInfo Item { get; set; }
        public BlogDetailViewModel(BlogInfo item = null)
        {
            Title = item?.BlogTitle;
            Item = item;
        }
    }
}
