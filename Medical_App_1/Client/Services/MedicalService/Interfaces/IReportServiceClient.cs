using Medical_App_1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Client.Services.MedicalService.Interfaces
{
    interface IReportServiceClient
    {
        public Task<Result<string>> GetPurchaseSingleReport(string BillNo);
    }
}
