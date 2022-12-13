
using Medical_App_1.Client.Models;
using Medical_App_1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Medical_App_1.Client.Services
{
    public class LoginServices : ILoginServices
    {
      
        private HttpClient _httpClient;
        public LoginServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
      
        public async Task<AuthenticationResponse> AuthenticateJWT(LoginViewModel model )
        {
            //creating authentication request
            AuthenticationRequest authenticationRequest = new AuthenticationRequest();
            authenticationRequest.EmailId = model.EmailId;
            authenticationRequest.password = model.password;

            //authenticating the request
            var httpMessageReponse = await _httpClient.PostAsJsonAsync<AuthenticationRequest>($"User/authenticatejwt", authenticationRequest);
           // var httpMessageReponse = await _httpClient.PostAsJsonAsync<AuthenticationRequest>($"authenticatejwt?EmailAddress=shyam@gmail.com&Password=ShyamSir");

            //sending the token to the client to store
            return await httpMessageReponse.Content.ReadFromJsonAsync<AuthenticationResponse>();
        }
    }
}
