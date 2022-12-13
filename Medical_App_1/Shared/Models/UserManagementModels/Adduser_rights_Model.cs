using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Medical_App_1.Shared.Models.UserManagementModels
{
    class Adduser_rights_Model:Menu1
    {
        //public IEnumerable<SelectListItem> Deptype { get; set; }

        public List<ListItems> Deptuser { get; set; }

        //[Required]
        //[Display(Name = "Department")]
        //public int depval { get; set; }
        public List<ListItems> Usertype { get; set; }

        [Required]
        [Display(Name = "User")]
        public int userval { get; set; }


        //public Adduser_rights()
        //{
        //    Items = new List<MenuItem>();
        //}

        public List<MenuItem> Items;



        public Adduser_rights_Model()
        {
            Items = new List<MenuItem>();
            this.MenulistList = new List<User_right>();
        }

        public List<User_right> MenulistList { get; set; }

        public class User_right
        {
            public string categoryid { get; set; }
            public bool IsSelected { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public int? Parentcategoryid { get; set; }
        }
        [Required]
        [Display(Name = "Captcha")]
        public string captcha { get; set; }
    }
}
