using Medical_App_1.Client.Services.MedicalService.Interfaces;
using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Medical_App_1.Client.Services.MedicalService
{
    public class PurchaseServiceClient: IPurchaseServiceClient
    {
        private HttpClient _httpClient;
        public PurchaseServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Result<List<ListItems>>> ListBillNo(Purchase model)
        {
            var httpMessageReponse = await _httpClient.PostAsJsonAsync<Purchase>($"api/Purchase/ListBillNo", model);

            return await httpMessageReponse.Content.ReadFromJsonAsync<Result<List<ListItems>>>();
        }
        public async Task<Result<List<ListItems>>> ListSuplier(Purchase model)
        {
           
            var httpMessageReponse = await _httpClient.PostAsJsonAsync<Purchase>($"api/Purchase/ListSuplier", model);

            return await httpMessageReponse.Content.ReadFromJsonAsync<Result<List<ListItems>>>();
        }
        public async Task<Result<Purchase>> PurchaseSingle(Purchase model)
        {
            var httpMessageReponse = await _httpClient.PostAsJsonAsync<Purchase>($"api/Purchase/PurchaseSingle", model);

            return await httpMessageReponse.Content.ReadFromJsonAsync<Result<Purchase>>();
        }
    }
}
