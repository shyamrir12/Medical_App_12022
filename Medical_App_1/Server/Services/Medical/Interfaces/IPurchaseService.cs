using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Services.Medical.Interfaces
{
   public interface IPurchaseService
    {
        public  Task<Result<List<ListItems>>> SelectBillNoList(string PurchaseType);
        public Task<Result<List<ListItems>>> SelectSuplierList(string AccountType);
        public  Task<Result<Purchase>> SelectIPurchaseByBill(string BillNo);
    }
}
