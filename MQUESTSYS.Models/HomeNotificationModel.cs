using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQUESTSYS.Models
{
    public class HomeNotificationModel
    {
        public string Module { get; set; }
        public long ClientGroupID { get; set; }

        public List<HomeNotificationDetailModel> Details { get; set; }

        public HomeNotificationModel()
        {
            Details = new List<HomeNotificationDetailModel>();
        }
    }
}
