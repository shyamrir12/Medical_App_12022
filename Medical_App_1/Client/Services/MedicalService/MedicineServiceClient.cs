using Medical_App_1.Client.Services.MedicalService.Interfaces;
using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Medical_App_1.Client.Services.MedicalService
{
    public class MedicineServiceClient:IMedicineServiceClient
    {
       
        private HttpClient _httpClient;
        public MedicineServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<int>> AddMedicine(Medicine model)
        {
            var httpMessageReponse = await _httpClient.PostAsJsonAsync<Medicine>($"api/Medicine/CRUDMedicine", model);
          
            return await httpMessageReponse.Content.ReadFromJsonAsync<Result<int>>();
           
        }

        public async Task<Result<Medicine>> ListMedicineSingle(Medicine model)
        {
            var httpMessageReponse = await _httpClient.PostAsJsonAsync<Medicine>($"api/Medicine/ListMedicineSingle", model);

            return await httpMessageReponse.Content.ReadFromJsonAsync<Result<Medicine>>();
        }

        public async Task<Result<List<ListItems>>> ListMedicineName(Medicine model)
        {
            var httpMessageReponse = await _httpClient.PostAsJsonAsync<Medicine>($"api/Medicine/ListMedicineName", model);

            return await httpMessageReponse.Content.ReadFromJsonAsync<Result<List<ListItems>>>();
        }
    }
}
