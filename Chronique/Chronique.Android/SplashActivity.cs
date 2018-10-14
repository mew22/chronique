using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Sfbusyindicator;
using Com.Syncfusion.Sfbusyindicator.Enums;

namespace Chronique.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
//            Log.Debug(TAG, "SplashActivity.OnCreate");
//
//            // creating LinearLayout
//            LinearLayout linLayout = new LinearLayout(this);
//            // specifying vertical orientation
//            linLayout.Orientation = Orientation.Vertical;
//            // creating LayoutParams  
//            ViewGroup.LayoutParams linLayoutParam = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
//
//            LinearLayout.LayoutParams parameters = new LinearLayout.LayoutParams(100, 100);
//            parameters.Gravity = GravityFlags.Bottom | GravityFlags.CenterHorizontal;
//
            // Hack to remove licence message
            SfBusyIndicator busyIndicator = new SfBusyIndicator(this);
//            busyIndicator.AnimationType = AnimationTypes.Ball;
//            busyIndicator.TextColor = Color.Azure;
//            busyIndicator.Title = "Loading...";
//            busyIndicator.ViewBoxHeight = 100;
//            busyIndicator.ViewBoxWidth = 100;
//            busyIndicator.IsBusy = true;
//            busyIndicator.LayoutParameters = parameters;
//
//            linLayout.AddView(busyIndicator);
//            SetContentView(linLayout, linLayoutParam);
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        void SimulateStartup()
        {
            Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
//            await Task.Delay(200); // Simulate a bit of startup work.
            Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Finish();
        }
    }
}