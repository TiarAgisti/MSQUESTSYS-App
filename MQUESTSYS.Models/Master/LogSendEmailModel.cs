using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQUESTSYS.Models;
using System.ComponentModel.DataAnnotations;

namespace MQUESTSYS.Models.Master
{
    public class LogSendEmailModel:PSIHeaderModel
    {
        [Required]
        public string SenderName { get; set; }
        [Required]
        public string ToName { get; set; }
        [Required]
        public string CCName { get; set; }
        [Required]
        public string MessageEmail { get; set; }
    }
}
