using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarEngine.App
{
    public static class AppLog
    {
        public static void Log(string msg,string area="")
        {
            Console.WriteLine(msg + "@" + area);
        }
    }
}
