﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MQUESTSYS.Models.Master
{
    public class RoleModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public List<RoleDetailModel> Details { get; set; }

        public string IsActiveDescription
        {
            get
            {
                if (IsActive)
                    return "Active";
                else
                    return "Inactive";
            }
        }

        public RoleModel()
        {
            IsActive = true;

            Details = new List<RoleDetailModel>();
        }
    }
}
