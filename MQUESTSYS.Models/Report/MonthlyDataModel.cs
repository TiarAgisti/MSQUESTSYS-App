using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MQUESTSYS.Util;

namespace MQUESTSYS.Models.Master
{
    public class MonthlyDataModel
    {
        public string Month { get; set; }
        public string Amount { get; set; }
        public string color { get; set; }
    }
}
