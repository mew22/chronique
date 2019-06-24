
using Android.App;
using Android.Runtime;
using Android.Widget;
using Chronique.Customs;
using Chronique.Droid;
using Chronique.Layout;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace Chronique.Droid
{

    [Preserve (AllMembers = true)]
    public class MessageAndroid : IMessageToast
        {
            public void LongAlert(string message)
            {
                Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
            }

            public void ShortAlert(string message)
            {
                Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
            }
        }

}