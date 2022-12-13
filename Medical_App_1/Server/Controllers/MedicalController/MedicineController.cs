using Medical_App_1.Server.Services.Medical;
using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using Microsoft.AspNetCore.Authorization;
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
    public class MedicineController : Controller
    {
        private IMedicineService _objIMedicineProvider;
        public MedicineController(IMedicineService objIMedicineProvider)
        {
            _objIMedicineProvider = objIMedicineProvider;
        }
        [Authorize(Roles = "Operator,Admin")]
        public async Task<Result<int>> CRUDMedicine(Medicine model)
        {
            if(model.Check=="1")
            {
                if (Convert.ToInt32( model.MId )>0)
                {
                    return await _objIMedicineProvider.UpdateItem(model);
                }
                else
                {
                    return await _objIMedicineProvider.InsertItem(model);
                }                
            }
            else
            {
                return await _objIMedicineProvider.DeleteItem(model.MId);
            }
         
        }

        public async Task<Result<Medicine>> ListMedicineSingle(Medicine model)
        {
            return await _objIMedicineProvider.SelectItemCollectionSingle(model.SMedicine);
               
        }

        public async Task<Result<List<ListItems>>> ListMedicineName(Medicine model)
        {           
          return await _objIMedicineProvider.SelectItemCallection(model.MName);            
        }
    }
}
