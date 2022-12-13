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
    public class SalesController : Controller
    {
        private readonly IWebHostEnvironment webHostEnveronment;
        private ISalesService objISalesProvider;
        public SalesController(IWebHostEnvironment _webHostEnvironment, ISalesService _objISalesProvider)
        {
            this.webHostEnveronment = _webHostEnvironment;
            this.objISalesProvider = _objISalesProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
