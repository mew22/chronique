
using Foundation;
using Microsoft.AppCenter.Distribute;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfCalendar.XForms.iOS;
using Syncfusion.SfPicker.XForms.iOS;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using UIKit;

namespace Chronique.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
		    Distribute.DontCheckForUpdatesInDebug();
		    FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            new SfCalendarRenderer();
		    new SfBusyIndicatorRenderer();
            SfListViewRenderer.Init();
		    SfPullToRefreshRenderer.Init();
		    SfPickerRenderer.Init();
            LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
