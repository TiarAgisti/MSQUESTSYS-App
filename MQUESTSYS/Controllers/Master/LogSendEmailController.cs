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

        private string recalculateEmail(string emailTo, string ownerEmail)
        {
            var collEmail = emailTo.Split(';');
            return (collEmail.Count() > 0) ? emailTo.Replace(';', ',') : ownerEmail;
        }

        public override MPL.Business.IGenericBFC<LogSendEmailModel> GetBFC()
        {
            return new LogSendEmailBFC();
        }

        public void EmailPrintOut(long logSendEmailID)
        {
            var logSendEmail = new LogSendEmailBFC().RetrieveByID(logSendEmailID);
            var subject = logSendEmail.SubjectEmail;
            var contentMessage = logSendEmail.MessageEmail;
            var recalcEmail = recalculateEmail(logSendEmail.ToName, "tiar.agisti.pbt@gmail.com");
            new EmailHelper().SendEmail(recalcEmail.ToString(), subject, contentMessage);
        }

        public override void CreateData(LogSendEmailModel obj)
        {
            base.CreateData(obj);
            EmailPrintOut(obj.ID);
        }
    }
}