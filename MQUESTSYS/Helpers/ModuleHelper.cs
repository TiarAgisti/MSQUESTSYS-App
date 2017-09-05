using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MQUESTSYS.Helpers
{
    public class ModuleHelper
    {
        public static Dictionary<string, string> ModuleList()
        {
            Dictionary<string, string> moduleList = new Dictionary<string, string>();
           

            /*Home*/
            moduleList["Dashboard"] = "Dashboard";

            /*Master*/
            moduleList["Customer"] = "Customer";
            moduleList["LogSendEmail"] = "Send Email";
            moduleList["User"] = "User";
            moduleList["Role"] = "Permission";
            moduleList["UserProfile"] = "User Profile";

            /*Setting*/
            moduleList["PrefixSetting"] = "Pengaturan Prefix";
            moduleList["CompanySetting"] = "Company Info";  

            return moduleList;
        }
    }
}