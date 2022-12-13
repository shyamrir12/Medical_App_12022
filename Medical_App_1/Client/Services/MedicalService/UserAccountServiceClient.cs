using Medical_App_1.Client.Services.MedicalService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Medical_App_1.Client.Services.MedicalService
{
    public class UserAccountServiceClient: IUserAccountServiceClient
    {
        private HttpClient _httpClient;
        public UserAccountServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
