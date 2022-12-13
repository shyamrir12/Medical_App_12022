using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Medical_App_1.Shared.Models.UserManagementModels
{
    class DmsHECategoryModel:Menu1
    {
        public DmsHECategoryModel()
        {
            hecategoryList = new List<DmsHECategoryModel>();
        }
        public List<ListItems> Documentcategory { get; set; }
        public List<ListItems> Documentissuedby { get; set; }
        public int hecatid { get; set; }

        [Required]
        [Display(Name = "Category Name English")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string categoryname { get; set; }

        [Required]
        [Display(Name = "Category Name Hindi")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string categorynamehindi { get; set; }
        public bool isactive { get; set; }

        [Required]
        [Display(Name = "captcha")]
        public string captcha { get; set; }
        [Required]
        [Display(Name = "Document IssuedBy")]


        public int documentissuedval { get; set; }
        [Required]
        [Display(Name = "Document Category")]
        public int documentcatval { get; set; }

        public string issuenameenglish { get; set; }
        public string documentnameenglish { get; set; }
        public List<DmsHECategoryModel> hecategoryList { get; set; }
    }
}
