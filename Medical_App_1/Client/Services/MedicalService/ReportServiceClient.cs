using Medical_App_1.Client.Services.MedicalService.Interfaces;
using Medical_App_1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Medical_App_1.Client.Services.MedicalService
{
    public class ReportServiceClient: IReportServiceClient
    {
        private HttpClient _httpClient;
        public ReportServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Result<string>> GetPurchaseSingleReport(string BillNo)
        {
           
            var httpMessageReponse = await _httpClient.PostAsJsonAsync($"api/Report/PurchaseSingleReport?BillNo="+ BillNo,"");
            return await httpMessageReponse.Content.ReadFromJsonAsync<Result<string>>();
        }
    }
}
