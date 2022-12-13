using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Medical_App_1.Client.Services;
using Medical_App_1.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Client.Pages.Authentication
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        public ILocalStorageService _localStorageService { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }
        [Inject]
        public ILoginServices LoginService { get; set; }

        public Models.LoginViewModel _LoginViewModel { get; set; } = new Models.LoginViewModel();
        [CascadingParameter]
        public Task<AuthenticationState> authenticationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
           
            var authState = await authenticationState;
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {

                 _navigationManager.NavigateTo("/profile", true);
                
            }
            
            
        }

        public async Task AuthenticateJWT()
        {
            AuthenticationResponse authenticationResponse = await LoginService.AuthenticateJWT(_LoginViewModel);
            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorageService.SetItemAsync("jwt_token", authenticationResponse.Token);
                _navigationManager.NavigateTo("/profile", true);
               
            }
            else
            {
                _toastService.ShowError("Invalid username or password");
            }
        }

    }
}
