using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Medical_App_1.Shared.Models.UserManagementModels
{
    class UserSectionMappingModel:Menu1
    {
        public List<ListItems> Documentissuedby { get; set; }
        // [Required(ErrorMessage = "Select ULB !")]
        // [RequiredArray(ErrorMessage = "Select ULB !")]
        [Display(Name = "ULB")]
        public int[] DepartmentIds { get; set; }

        [Required(ErrorMessage = "Select User !")]
        [Display(Name = "Users")]
        public int UserId { get; set; }

        public string Departments { get; set; }

        public List<ListItems> DepartmentList { get; set; }
        public List<ListItems> UserList { get; set; }

        [Required]
        [Display(Name = "Captcha")]
        public string captcha { get; set; }

        [Required(ErrorMessage = "Select District !")]
        [Display(Name = "District")]
        public int documentissuedval { get; set; }

        // public string issuenameenglish { get; set; }
    }
}
