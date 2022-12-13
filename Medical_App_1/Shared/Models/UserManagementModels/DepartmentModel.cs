using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medical_App_1.Shared.Models.UserManagementModels
{
    class DepartmentModel:Menu1
    {
        public DepartmentModel()
        {
            departmentList = new List<DepartmentModel>();
        }
        public List<ListItems> Documentissuedby { get; set; }
        public List<ListItems> UlbTypeList { get; set; }
        public int deptid { get; set; }

        [Required]
        [Display(Name = "Department Name English")]
        public string deptname { get; set; }

        [Display(Name = "Department Name Hindi")]
        public string deptnamehindi { get; set; }
        public bool isactive { get; set; }

        [Required]
        [Display(Name = "captcha")]
        public string captcha { get; set; }

        public List<DepartmentModel> departmentList { get; set; }
        [Required]
        [Display(Name = "Document IssuedBy")]
        public int documentissuedval { get; set; }

        public string issuenameenglish { get; set; }
        public string ULBType { get; set; }
    }
}
