using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQUESTSYS.EDM
{
    public partial class v_Rpt_Sales
    {
        public decimal AssetTotal
        {
            get
            {
                return Convert.ToDecimal(AssetPrice) * Convert.ToDecimal(Quantity);
            }
        }

        public decimal PriceTotal
        {
            get
            {
                return Convert.ToDecimal(Price) * Convert.ToDecimal(Quantity);
            }
        }

        public decimal TaxAmountTotal
        {
            get
            {
                return Convert.ToDecimal(TaxAmount) * Convert.ToDecimal(Quantity);
            }
        }

        public decimal GrandTotal
        {
            get
            {
                return PriceTotal + TaxAmountTotal;
            }
        }

        public string AssetTotalDesc
        {
            get
            {
                return "Rp " + AssetTotal.ToString("N0");
            }
        }

        public string PriceTotalDesc
        {
            get
            {
                var currencyDesc = "";

                if (Currency == (int)Util.Currency.IDR)
                    currencyDesc = "Rp";
                else
                    currencyDesc = "$";

                return currencyDesc + " " + PriceTotal.ToString("N0");
            }
        }

        public string TaxAmountTotalDesc
        {
            get
            {
                var currencyDesc = "";

                if (Currency == (int)Util.Currency.IDR)
                    currencyDesc = "Rp";
                else
                    currencyDesc = "$";

                return currencyDesc + " " + TaxAmountTotal.ToString("N0");
            }
        }

        public string GrandTotalDesc
        {
            get
            {
                var currencyDesc = "";

                if (Currency == (int)Util.Currency.IDR)
                    currencyDesc = "Rp";
                else
                    currencyDesc = "$";

                return currencyDesc + " " + GrandTotal.ToString("N0");
            }
        }
    }
}
