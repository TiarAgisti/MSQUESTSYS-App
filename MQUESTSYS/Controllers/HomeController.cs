using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using MQUESTSYS.EDM;
using MQUESTSYS.DA;
using MQUESTSYS.Util;
using MQUESTSYS.BF.Master;
using MQUESTSYS.BF;
using MQUESTSYS.Helpers;
using MQUESTSYS.Models;
//using MQUESTSYS.BF.Transaction;
//using MQUESTSYS.Models.Master;
//using MQUESTSYS.Models.Transaction;


namespace MQUESTSYS.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var menu = MenuHelper.GetMenuList();

            string textFormat = "{0} {1} {2}";

            //var customerGroupList = new ClientGroupBFC().RetrieveAll();

            var count = 0;
            var filter = new List<MPL.Business.SelectFilter>();

            var notificationList = new List<HomeNotificationModel>();
            int roleID = MembershipHelper.GetRoleID();
            string username = MembershipHelper.GetUserName();


            ViewBag.Year = DateTime.Now.Year.ToString();
            return View();
        }

        public static string GetClientIPAddress()
        {
            return "";
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
