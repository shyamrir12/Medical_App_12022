using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models.Medical
{
    class UserAccount
    {
        public UserAccount()
        {
            UserAccountPaymentList = new List<UserAccountPayment>();
            UserAccountList = new List<ListItems>();
        }
        public int SupId { get; set; }
        public string SupName { get; set; }
        public string SupShoName { get; set; }
        public string SupAdd { get; set; }
        public string SupConNo { get; set; }
        public decimal OpeningAmount { get; set; } = 0;
        public string AccountType { get; set; }
        public int? AccountTypeId { get; set; }
        public decimal BalLimit { get; set; } = 0;
        public string DLNO { get; set; }
        public string GSTNO { get; set; }
        public decimal BalanceAmount { get; set; } = 0;


        public string AccountPhoto { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string IPAddress { get; set; }
        public int? CreatedByUserID { get; set; }
        public int? UpdatedByUserID { get; set; }
        public bool? IsActive { get; set; }
        public int? SinkStatues { get; set; }
        public int? DivisionID { get; set; }
        public int? ProfileID { get; set; }

        public List<UserAccountPayment> UserAccountPaymentList { get; set; }
        public List<ListItems> UserAccountList { get; set; }


    }
    class UserAccountPayment
    {
        public int PayId { get; set; }
        public DateTime? PayDate { get; set; } = System.DateTime.Now;
        public decimal Amount { get; set; } = 0;
        public string Remarks { get; set; }
        public int SupId { get; set; }
    }
}
