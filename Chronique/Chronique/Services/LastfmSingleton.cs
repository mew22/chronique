using System;
using System.Collections.Generic;
using System.Text;
using IF.Lastfm.Core.Api;

namespace Chronique.Services
{
    public sealed class LastfmSingleton
    {
        public static readonly string API_KEY_LAST_FM = "f8f9fc1fbe1b7f5abc8728f101b181cb";

        public static readonly string API_SECRET_LAST_FM = "bff89e9d60b34d1c87f1283c995399f7";

        private LastfmClient lastFm;

        public LastfmClient LastFm => lastFm;

        private static readonly LastfmSingleton instance = new LastfmSingleton();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static LastfmSingleton()
        {
        }

        private LastfmSingleton()
        {
            lastFm = new LastfmClient(API_KEY_LAST_FM, API_SECRET_LAST_FM);
        }

        public static LastfmSingleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
