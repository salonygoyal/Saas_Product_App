using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SaasProductApp
{
    static class ConfigurationDetails
    {
        private static Dictionary<string, string> applicationSettings;

        static ConfigurationDetails()
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count > 0)
            {
                applicationSettings = new Dictionary<string, string>();
                foreach (var key in appSettings.AllKeys)
                {
                    applicationSettings.Add(key, appSettings[key]);
                }
            }
        }

        public static string GetConfiguration(string key)
        {
            return applicationSettings != null ? applicationSettings[key] : String.Empty;
        }
    }
}
