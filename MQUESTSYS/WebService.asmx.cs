using System.Collections.Generic;
using System.Web.Services;
using MQUESTSYS.Models.Master;
//using MQUESTSYS.Models.Transaction;
using MQUESTSYS.BF.Master;
//using MQUESTSYS.BF.Transaction;
using System;

namespace MQUESTSYS
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        #region Customer
        [WebMethod]
        public List<CustomerModel> RetrieveCustomerByKey(string q, int limit)
        {
            return new CustomerBFC().RetrieveAutoComplete(q);
        }

        [WebMethod]
        public CustomerModel RetrieveCustomer(string customerName)
        {
            return new CustomerBFC().RetrieveByCodeOrName(customerName);
        }
        #endregion
       
    }
}
