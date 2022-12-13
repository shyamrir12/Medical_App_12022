using ShyamTech.Components.LoginComponent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamTech.Components.LoginComponent.Services
{
    public interface ILoginServices
    {
        public Task<AuthenticationResponse> AuthenticateJWT(LoginViewModel model);
    }
}
