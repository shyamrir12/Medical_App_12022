using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models.UserManagementModels
{
    class RecoverPasswordModel
    {
        public string Email { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string username { get; set; }

        public string RecoveryPassword { get; set; }

        [Required]
        [Display(Name = "captcha")]
        public string captcha { get; set; }
    }
}
