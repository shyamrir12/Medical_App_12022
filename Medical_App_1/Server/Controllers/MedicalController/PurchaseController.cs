using Medical_App_1.Server.Services.Medical;
using Medical_App_1.Server.Services.Medical.Interfaces;
using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Controllers.MedicalController
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class PurchaseController : ControllerBase
    {
        private IPurchaseService _objIPurchaseProvider;

        public PurchaseController(IPurchaseService objIPurchaseProvider)
        {
            _objIPurchaseProvider = objIPurchaseProvider;
        }
        public async Task<Result<List<ListItems>>> ListBillNo(Purchase model)
        {
            return await _objIPurchaseProvider.SelectBillNoList(model.PurchaseType);
        }
        public async Task<Result<List<ListItems>>> ListSuplier(Purchase model)
        {
            return await _objIPurchaseProvider.SelectSuplierList(model.SuplierType);
        }
        public async Task<Result<Purchase>> PurchaseSingle(Purchase model)
        {
            return await _objIPurchaseProvider.SelectIPurchaseByBill(model.BillNo);
        }
    }
}
