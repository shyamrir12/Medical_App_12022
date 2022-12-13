using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models
{
    public class AuthenticationRequest
    {
        public string EmailId { get; set; }
        public string password { get; set; }
    }
}
