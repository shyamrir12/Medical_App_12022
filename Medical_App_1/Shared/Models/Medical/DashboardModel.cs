using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models.Medical
{
    class DashboardModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? TotalSalesBill { get; set; }
        public int? TotalPurchaseBill { get; set; }
        public long? TotalSales { get; set; }
        public int? TotalPurchase { get; set; }
        public long? TotalIncome { get; set; }
        public long? TotalExpances { get; set; }
       
        public int? DeptId { get; set; }
    }
}
