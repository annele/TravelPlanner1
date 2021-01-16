using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Utils
{
    public static class Log
    {
        public static void LogExceptions(string exceptionText)
        {
            File.AppendAllText("log.txt", DateTime.Now + " : " + exceptionText);
        }

    }
}
