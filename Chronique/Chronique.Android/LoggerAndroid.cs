using Android.Util;
using Chronique.Customs;
using Chronique.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(LoggerAndroid))]
namespace Chronique.Droid
{
    [Preserve(AllMembers = true)]
    class LoggerAndroid : ILogger
    {
        public void error(string tag, string msg)
        {
            Log.Error(tag, msg);
        }

        public void debug(string tag, string msg)
        {
            Log.Debug(tag, msg);
        }

        public void info(string tag, string msg)
        {
            Log.Info(tag, msg);
        }
    }
}