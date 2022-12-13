using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Medical_App_1.Server.Services.Medical
{
   public interface IMedicineService
    {
        public Task<Result<List<Medicine>>> SelectAll();
        public Task<Result<int>> UpdateBox(Medicine model);
        public Task<Result<List<ListItems>>> SelectItemCallection(string MName);
        public Task<Result<Medicine>> SelectItemCollectionSingle(string MNameUnit);
        public Task<Result<int>> UpdateItem(Medicine model);
        public Task<Result<int>> InsertItem(Medicine model);
        public Task<Result<int>> DeleteItem(int MId);
    }
}
