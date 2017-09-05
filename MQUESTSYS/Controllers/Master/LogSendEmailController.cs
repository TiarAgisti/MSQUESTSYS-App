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
    public class LogSendEmailController: PSIGenericController<LogSendEmailModel>
    {
        public LogSendEmailController()
        {
            base.ModuleID = "LogSendEmail";
        }

        public override MPL.Business.IGenericBFC<LogSendEmailModel> GetBFC()
        {
            return new LogSendEmailBFC();
        }
    }
}