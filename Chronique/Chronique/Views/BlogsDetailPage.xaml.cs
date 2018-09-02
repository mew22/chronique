using System;

using Xamarin.Forms;

namespace Chronique
{
    public partial class BlogsDetailPage : ContentPage
    {

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public BlogsDetailPage()
        {
            Title = "La Chronique";
            InitializeComponent();

        }
        public BlogsDetailPage(BlogDetailViewModel obj)
        {
            Title = "La Chronique";
            BindingContext = obj;
            InitializeComponent();

        }
    }
}
