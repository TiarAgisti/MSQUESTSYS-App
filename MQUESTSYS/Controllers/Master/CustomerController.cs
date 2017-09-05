using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MQUESTSYS.BF.Master;
using MQUESTSYS.Helpers;
using MQUESTSYS.Models.Master;
using MQUESTSYS.Util;

namespace MQUESTSYS.Controllers.Master
{
    public class CustomerController : PSIGenericController<CustomerModel>
    {
        public CustomerController()
        {
            base.ModuleID = "Customer";
        }

        public override MPL.Business.IGenericBFC<CustomerModel> GetBFC()
        {
            return new CustomerBFC();
        }
    }
}
