using System;
using MQUESTSYS.Models;
using System.ComponentModel.DataAnnotations;

namespace MQUESTSYS.Models.Master
{
   
    public class CustomerModel:PSIHeaderModel
    {
        //Table Only
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }


        //[Required]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid e-mail adress")]
        //[Display(Name = "Email address")]
        //[Required(ErrorMessage = "The email address is required")]
        //[Email(ErrorMessage = "The email address is not valid")]
        [Required]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Email not valid")]
        public string Email { get; set; }
       
        public bool IsActive { get; set; }
        public string City { get; set; }
        public string Provinsi { get; set; }
        public string Zip { get; set; }

        //Read Only
        public string AutoCompleteDisplay { get; set; }
        public string AutoCompleteSearchable { get; set; }

        public string IsActiveDescription
        {
            get
            {
                if (IsActive)
                    return "Active";
                else
                    return "Not Active";
            }
        }

    }
}
