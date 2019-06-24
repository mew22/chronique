using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronique.Customs
{
    public interface IMessageToast
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}