using Chronique.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chronique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
            InitializeComponent();
            BindingContext = obj;
        }
    }
}