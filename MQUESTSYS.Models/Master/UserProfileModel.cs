using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MQUESTSYS.Models.Master
{
    public class UserProfileModel : PSIHeaderModel
    {
        /*TABLE MANUAL*/
        [Required]
        public string UserName { get; set; }
        [Required]
        public string DisplayName { get; set; }

        /*READ ONLY*/
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public long RoleID { get; set; }
        public string RoleName { get; set; }
        public Boolean UserIsActive { get; set; }
        public string UserIsActiveDescription { get; set; }
    }
}
