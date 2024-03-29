﻿using Chronique.Models;

namespace Chronique.ViewModels
{
    [Preserve(AllMembers = true)]
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