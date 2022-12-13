using Medical_App_1.Shared.Models.UserManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models.UserManagementModels
{
    public class Menu1
    {
        public Menu1()
        {
            Items = new List<MenuItem>();
        }

        // User Information
        public string role { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string designation { get; set; }
        public string userimage { get; set; }
        public string department { get; set; }


        public List<MenuItem> Items;
    }
}