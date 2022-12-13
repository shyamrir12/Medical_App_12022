
using Microsoft.AspNetCore.Components;

using ShyamTech.Components.LoginComponent.Model;
using ShyamTech.Components.LoginComponent.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamTech.Components.LoginComponent
{
   public class LoginComponentBase : ComponentBase
    {
        [Inject]
        public NavigationManager _navigationManager { get; set; }
       

        public LoginViewModel _LoginViewModel { get; set; } = new LoginViewModel();
       

        protected override async Task OnInitializedAsync()
        {

           

                //_navigationManager.NavigateTo("/fetchdata", true);
            


        }

        public async Task AuthenticateJWT()
        {
            
        }

    }
}

