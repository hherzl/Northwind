using System;
using System.Configuration;

namespace NorthwindApi.Helpers
{
    public class AppSettingsHelper
    {
        public static String ErrorLogPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorLogPath"];
            }
        }

        public static String JsonErrorLogPath
        {
            get
            {
                return ConfigurationManager.AppSettings["JsonErrorLogPath"];
            }
        }
    }
}
