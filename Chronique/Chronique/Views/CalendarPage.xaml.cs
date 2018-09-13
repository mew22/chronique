using System;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chronique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            Title = "La Chronique";
            InitializeComponent();

            calendarSorties.ShowInlineEvents = true;


            CalendarInlineEvent events = new CalendarInlineEvent();
            events.StartTime = new DateTime(2017, 11, 3, 5, 0, 0);
            events.EndTime = new DateTime(2017, 11, 3, 7, 0, 0);
            events.Subject = "Sortie Novembre: 105z";
            events.Color = Color.Fuchsia;

            CalendarInlineEvent events2 = new CalendarInlineEvent();
            events2.StartTime = new DateTime(2017, 11, 3, 11, 0, 0);
            events2.EndTime = new DateTime(2017, 11, 3, 15, 0, 0);
            events2.Subject = "Sortie Novembre: 106z";
            events2.Color = Color.DeepSkyBlue;

            CalendarEventCollection collection = new CalendarEventCollection();
            collection.Add(events);
            collection.Add(events2);

            calendarSorties.DataSource = collection;
        }
        async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
