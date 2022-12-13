using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models.UserModels
{

    public class User
    {

         public int UserID { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string Role { get; set; }
        public Nullable<int> subroleid { get; set; }
        public string Name { get; set; }
        public string OrganizationName { get; set; }
        public string EmailId { get; set; }
        public string Mobile_No { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Ipaddress { get; set; }
        public Nullable<int> loginattempt { get; set; }
        public Nullable<bool> Activation { get; set; }
        public Nullable<System.DateTime> logindate { get; set; }
        public string Designation { get; set; }
        public string photo { get; set; }
        public string Deptid { get; set; }
        public string DocSectionid { get; set; }
        public string DivisionId { get; set; }
        public string WardId { get; set; }
        public string RasoiId { get; set; }


    }
   
}
