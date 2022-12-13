

using Medical_App_1.Client.Models;
using Medical_App_1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Client.Services
{
    public interface ILoginServices
    {
        public Task<AuthenticationResponse> AuthenticateJWT(LoginViewModel model);
    }
}
