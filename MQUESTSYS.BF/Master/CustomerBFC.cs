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
    public class CustomerBFC:PSIGenericBFC<Customer,v_Customer,CustomerModel>
    {
        public override void Create(CustomerModel dr)
        {
            dr.Code = this.GenerateCode("CS", 5);
            base.Create(dr);
        }

        public List<CustomerModel> RetrieveAutoComplete(string key)
        {
            return new MQUESTSYSDAC().RetrieveCustomerAutoComplete(key);
        }

        public CustomerModel RetrieveByCodeOrName(string customerName)
        {
            return new MQUESTSYSDAC().RetrieveCustomerByCodeOrName(customerName);
        }
    }
}
