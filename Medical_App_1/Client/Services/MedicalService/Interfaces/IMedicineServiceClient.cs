using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Medical_App_1.Client.Services.MedicalService.Interfaces
{
    interface IMedicineServiceClient
    {
        public  Task<Result<int>> AddMedicine(Medicine model);

        public Task<Result<Medicine>> ListMedicineSingle(Medicine model);
        public Task<Result<List<ListItems>>> ListMedicineName(Medicine model);
    }
}
