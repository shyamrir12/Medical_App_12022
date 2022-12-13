using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medical_App_1.Shared.Models.Medical
{
    public class Purchase
    {
        public Purchase()
        {
            PurchaseItemList = new List<PurchaseItem>();
            PurchaseBillNoList = new List<ListItems>();
            SuplierList = new List<ListItems>();
            MedicineList = new List<ListItems>();
           
        }

        public string BillNo { get; set; }
        public DateTime? Purdate { get; set; } = DateTime.Today;
        public string SupId { get; set; }
        public string SupName { get; set; }
        public decimal ValueOfGood { get; set; } = 0;
        public decimal Descount { get; set; } = 0;
        public decimal Vat { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public decimal NetAmount { get; set; } = 0;
        public string PurchaseType { get; set; }
        public string SuplierType { get; set; }
        public string DisplayType { get; set; }
        public List<PurchaseItem> PurchaseItemList { get; set; }

        public List<ListItems> PurchaseBillNoList { get; set; }
        public List<ListItems> SuplierList { get; set; }
        public List<ListItems> MedicineList { get; set; }
    
        
    }

    public class PurchaseItem
    {
        public string PurItemId { get; set; }
        public int SNo { get; set; }
        public string MName { get; set; } // as MedicineName_Unit
        public int Stri { get; set; } = 0;
        public int Tab { get; set; } = 0;
        public decimal Disc { get; set; } = 0;
        public int Free { get; set; } = 0;
        public int Vat { get; set; } = 0;

        //  public string GST { get; set; }
        //  public string ExpDate { get; set; }
        public DateTime? ExpDate { get; set; } 
        public string BatchNo { get; set; }
        public decimal DescA { get; set; } = 0;
        public decimal VatA { get; set; } = 0; // as GSTA,
        public decimal Rate { get; set; } = 0;
        public decimal MRP { get; set; } = 0;
        public decimal Amount { get; set; } = 0;
        public int MId { get; set; }
        public string PurId { get; set; }

        public string Action { get; set; } = "Delete";
        public bool OpenDetails { get; set; } = false;
        public short Box { get; set; } = 0;
        public decimal VOM { get; set; } = 0;
        public decimal TVOMDESC { get; set; } = 0;

    }
}
