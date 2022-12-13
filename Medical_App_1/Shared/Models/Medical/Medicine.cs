using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medical_App_1.Shared.Models.Medical
{
    public class Medicine
    {
        public Medicine()
        {
            
            MedicineList=new List<ListItems>  ();
        }
        public List<ListItems> MedicineList { get; set; }
        public int MId { get; set; }
        public string MName { get; set; }
        public string MUnit { get; set; }
        public string MCN { get; set; }
        public decimal MRate { get; set; }
        public int MVAT { get; set; }
        public short MBox { get; set; }
        public string OM { get; set; }
       public string HSN { get; set; }
        public int SGST { get; set; }
        public int IGST { get; set; }
        public string Check { get; set; }
        public decimal MMRP { get; set; }
         public string SMedicine { get; set; }
    }
}
