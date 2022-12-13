using Medical_App_1.Server.Services.Medical.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Controllers.MedicalController
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class UserAccountController : Controller
    {
        private readonly IWebHostEnvironment webHostEnveronment;
        private IUserAccountService objIUserAccountProvider;
        public UserAccountController(IWebHostEnvironment _webHostEnvironment, IUserAccountService _objIUserAccountProvider)
        {
            this.webHostEnveronment = _webHostEnvironment;
            this.objIUserAccountProvider = _objIUserAccountProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
