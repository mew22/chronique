using System;
using System.Collections.Generic;
using System.Text;

namespace Chronique.Customs
{
    public interface ILogger
    {
        void error(String tag, String msg);
        void debug(String tag, String msg);
        void info(String tag, String msg);
    }
}