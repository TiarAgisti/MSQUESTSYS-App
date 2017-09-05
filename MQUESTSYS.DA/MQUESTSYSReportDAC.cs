using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using MPL;
using MPL.Business;
using MQUESTSYS.EDM;
using MQUESTSYS.ReportEDS;
using System.Data.SqlClient;

namespace MQUESTSYS.DA
{
    public class MQUESTSYSReportDAC
    {
        private void ApplyFilter<T>(ref IQueryable<T> query, List<SelectFilter> filters)
        {
            if (filters != null)
            {
                object[] param = null;
                string statements = SelectFilter.Build(filters, out param);

                if (!string.IsNullOrEmpty(statements))
                    query = query.Where(statements, param);
            }
        }

        #region Company Setting

        public MQUESTSYSReportEDSC.CompanySettingDTRow RetrieveCompanySetting()
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.CompanySetting
                        select i;
            
            MQUESTSYSReportEDSC.CompanySettingDTRow dr = new MQUESTSYSReportEDSC.CompanySettingDTDataTable().NewCompanySettingDTRow();

            if (query.FirstOrDefault() != null)
                ObjectHelper.CopyProperties(query.FirstOrDefault(), dr);
            else
                return null;

            return dr;
        }

        #endregion

       
    }
}
