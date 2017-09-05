using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQUESTSYS.DA;
using MQUESTSYS.Models.Master;
using MQUESTSYS.EDM;
using MPL.Business;
using MQUESTSYS.ReportEDS;

namespace MQUESTSYS.BF.Master
{
    public class CompanySettingBFC:GenericBFC<CompanySetting,CompanySetting,CompanySettingModel>
    {
        public override string GenerateID()
        {
            throw new NotImplementedException();
        }

        protected override GenericDAC<CompanySetting, CompanySettingModel> GetDAC()
        {
            return new GenericDAC<CompanySetting, CompanySettingModel>("ID", false);
        }

        protected override GenericDAC<CompanySetting, CompanySettingModel> GetViewDAC()
        {
            return new GenericDAC<CompanySetting, CompanySettingModel>("ID", false);
        }

        public CompanySettingModel Retrieve()
        {
            return new MQUESTSYSDAC().RetrieveCompanySetting();
        }

        public MQUESTSYSReportEDSC.CompanySettingDTRow RetrieveForPrintOut()
        {
            return new MQUESTSYSReportDAC().RetrieveCompanySetting();
        }

    }
}
