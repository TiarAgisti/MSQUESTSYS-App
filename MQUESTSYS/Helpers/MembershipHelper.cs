using MQUESTSYS.BF.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MQUESTSYS.Helpers
{
    public class MembershipHelper
    {
        public static string GetUserName()
        {
            if (Membership.GetUser() == null)
                return "System";
            else
                return Membership.GetUser().UserName;
        }

        public static int GetRoleID()
        {
            var profile = ProfileCommon.GetProfile(GetUserName());

            return profile.RoleID;
        }

        public static int GetRoleID(string userName)
        {
            var profile = ProfileCommon.GetProfile(userName);

            return profile.RoleID;
        }
        public static string GetDisplayName()
        {
            return new UserProfileBFC().RetrieveByUserName(GetUserName()).DisplayName;
        }
    }
}