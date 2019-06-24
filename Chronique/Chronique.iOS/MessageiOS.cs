﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chronique.Customs;
using Chronique.iOS;
using Chronique.Layout;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(MessageIOS))]

namespace Chronique.iOS
{
    [Preserve(AllMembers = true)]
    class MessageIOS : IMessageToast
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;
        NSTimer alertDelay;
        UIAlertController alert;

        public void LongAlert(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }

        public void ShortAlert(string message)
        {
            ShowAlert(message, SHORT_DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) => { dismissMessage(); });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }

            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}