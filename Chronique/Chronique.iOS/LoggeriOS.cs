using Chronique.Customs;
using Chronique.iOS;


[assembly: Xamarin.Forms.Dependency(typeof(LoggeriOS))]

namespace Chronique.iOS
{
    [Preserve(AllMembers = true)]
    class LoggeriOS : ILogger
    {
        public void error(string tag, string msg)
        {
            System.Console.WriteLine(tag + ": " + msg);
        }

        public void debug(string tag, string msg)
        {
            System.Console.WriteLine(tag + ": " + msg);
        }

        public void info(string tag, string msg)
        {
            System.Console.WriteLine(tag + ": " + msg);
        }
    }
}