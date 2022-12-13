using Medical_App_1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Services.Medical.Interfaces
{
   public interface IReportService
    {
        public Task<Result<DataSet>> SelectPurchaseSingleReport(string BillNo);
    }
}
