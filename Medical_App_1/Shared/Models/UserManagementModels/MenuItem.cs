using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models.UserManagementModels
{
    public class MenuItem
    {
        public MenuItem()
        {
            this.ChildMenuItems = new List<MenuItem>();
        }

        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemPath { get; set; }
        public string MenuName { get; set; }
        public Nullable<int> ParentItemId { get; set; }
        public virtual ICollection<MenuItem> ChildMenuItems { get; set; }

    }
}