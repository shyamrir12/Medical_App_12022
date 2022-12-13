using Medical_App_1.Server.Services.UserManage.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly IWebHostEnvironment webHostEnveronment;
        private IRegisterUserService objIRegisterUserProvider;
        public RegisterController(IWebHostEnvironment _webHostEnvironment, IRegisterUserService _objIRegisterUserProvider)
        {
            this.webHostEnveronment = _webHostEnvironment;
            this.objIRegisterUserProvider = _objIRegisterUserProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
