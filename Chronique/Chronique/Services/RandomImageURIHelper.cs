using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronique.Services
{
    public static class RandomImageURIHelper
    {
        public static string GetRandomImageUrl(int width = 500, int height = 500)
        {
            //return string.Format("https://loremflickr.com/{0}/{1}", width, height);
//            return string.Format("https://picsum.photos/{0}/{1}/?random", width, height);
            return string.Format("http://lorempixel.com/{0}/{1}/people/", width, height);
        }
    }
}