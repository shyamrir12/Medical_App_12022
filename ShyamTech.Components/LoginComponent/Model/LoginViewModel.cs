using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamTech.Components.LoginComponent.Model
{
    public class LoginViewModel
    {
        public string EmailId { get; set; }
        public string password { get; set; }
        public bool RememberMe { get; set; }
    }
}
