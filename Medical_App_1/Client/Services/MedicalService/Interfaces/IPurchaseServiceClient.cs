using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Client.Services.MedicalService.Interfaces
{
    interface IPurchaseServiceClient
    {
        public Task<Result<List<ListItems>>> ListBillNo(Purchase model);
        public Task<Result<List<ListItems>>> ListSuplier(Purchase model);
        public Task<Result<Purchase>> PurchaseSingle(Purchase model);
        
    }
}
