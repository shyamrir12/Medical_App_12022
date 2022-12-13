using Medical_App_1.Client.Services.MedicalService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Medical_App_1.Client.Services.MedicalService
{
    public class SalesServiceClient: ISalesServiceClient
    {
        private HttpClient _httpClient;
        public SalesServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
