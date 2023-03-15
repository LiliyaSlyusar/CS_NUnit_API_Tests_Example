using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_NUnit_API_Tests_Example.Helpers
{
    internal class Logger
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogInfo(object message)
        {
            log.Info(message);
            Debug.WriteLine(message);
        }

        public static void LogError(object message)
        {
            log.Error(message);
            Debug.WriteLine(message);
        }

        public void LogDebug(object message)
        {
            log.Debug(message);
            Debug.WriteLine(message);
        }
    }
}
