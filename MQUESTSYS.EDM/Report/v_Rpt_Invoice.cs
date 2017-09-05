using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQUESTSYS.EDM
{
    public partial class v_Rpt_Invoice
    {
        public decimal GrandTotal
        {
            get
            {
                return Convert.ToDecimal(Amount + TaxAmount);
            }
        }
    }
}
