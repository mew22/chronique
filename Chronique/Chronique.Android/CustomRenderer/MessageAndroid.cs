using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Chronique.Droid.CustomRenderer;
using Chronique.Layout;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace Chronique.Droid.CustomRenderer
{
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