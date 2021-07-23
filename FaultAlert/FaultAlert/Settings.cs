using System.Collections.Generic;
using System.Configuration;

namespace FaultAlert
{
    static class Settings
    {
        public static string MailHost { 
            get
            {
                return ConfigurationManager.AppSettings["mail.host"];
            }
        }

        public static int MailPort
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["mail.port"]);
            }
        }

        public static string MailUser
        {
            get
            {
                return ConfigurationManager.AppSettings["mail.user"];
            }
        }

        public static string MailPass
        {
            get
            {
                return ConfigurationManager.AppSettings["mail.pass"];
            }
        }

        public static bool MailRequireSSL
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["mail.requireSSL"]);
            }
        }

        public static bool MailRequireTLS
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["mail.requireTLS"]);
            }
        }

        public static bool MailRequireAut
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["mail.requireAuth"]);
            }
        }

        public static List<string> MailTo
        {
            get
            {
                return new List<string>(ConfigurationManager.AppSettings["mail.to"].Split(","));
            }
        }

        public static string[] SearchTerms
        {
            get
            {
                return ConfigurationManager.AppSettings["searchTerms"].Split(",");
            }
        }
    }
}
