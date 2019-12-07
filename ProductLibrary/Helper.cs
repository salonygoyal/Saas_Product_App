using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    public sealed class Helper
    {
        internal static void LogEvent(string message, EventLogEntryType msgType)
        {
            try
            {
                using (EventLog log = new EventLog("SaaSApp"))
                {
                    log.Source = "SaasApp";
                    log.WriteEntry(message, msgType);
                }
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog("App");
                string errMsg = string.Format("Information for error : {0}", ex.Message);
                log.WriteEntry(errMsg);
            }
        }
    }
}
