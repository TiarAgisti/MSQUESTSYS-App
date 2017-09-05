using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQUESTSYS.EDM;
using MQUESTSYS.Models.Master;
using MPL.Business;
using MQUESTSYS.BF;
using MQUESTSYS.DA;

namespace MQUESTSYS.BF.Master
{
    public class LogSendEmailBFC: PSIGenericBFC<LogSendEmail, v_LogSendEmail, LogSendEmailModel>
    {
        public override void Create(LogSendEmailModel dr)
        {
            dr.Code = this.GenerateCode("CS", 5);
            base.Create(dr);
        }

    }
}
