using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models.UserManagementModels
{
    class DmsIssuedByModel:Menu1
    {
        public DmsIssuedByModel()
        {
            issuedByList = new List<DmsIssuedByModel>();
        }
        public int issuedid { get; set; }

        [Required]
        [Display(Name = "IssuedBy Name English")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string issuedbyname { get; set; }

        [Required]
        [Display(Name = "IssuedBy Name Hindi")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string issuedbynamehindi { get; set; }
        public bool isactive { get; set; }

        [Required]
        [Display(Name = "captcha")]
        public string captcha { get; set; }

        public List<DmsIssuedByModel> issuedByList { get; set; }
    }
}
