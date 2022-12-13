using AspNetCore.Reporting;
using Medical_App_1.Server.Services.Medical.Interfaces;
using Medical_App_1.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Controllers.MedicalController
{
    [Route("api/{controller}/{action}")]
    [ApiController]
   [Authorize]
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment webHostEnveronment;
        private IReportService objIReportProvider;
        public ReportController(IWebHostEnvironment _webHostEnvironment, IReportService _objIReportProvider)
        {
            this.webHostEnveronment = _webHostEnvironment;
            this.objIReportProvider = _objIReportProvider;
        }
        public async Task<Result<string>> PurchaseSingleReport(string BillNo)
        {
            string mimetype = "";
            int extention = 1;
            int reporttype = 1;
            Result<string> r = new Result<string>(); 
            var result = await objIReportProvider.SelectPurchaseSingleReport(BillNo);

            var path = $"{this.webHostEnveronment.ContentRootPath}//Report//PurchaseSingle.rdlc";
            Dictionary<string, string> perameter = new Dictionary<string, string>();
            perameter.Add("param", "testparam_val");
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet1", result.Data.Tables[0]);
            if (reporttype == 1)
            {
                var res = localReport.Execute(RenderType.Pdf, extention, perameter, mimetype);
                // return File(res.MainStream, "application/pdf");
                r.Data = Convert.ToBase64String(res.MainStream, 0, res.MainStream.Length);
                r.Status = true;
                r.Message = new List<string>() { "Pdf!" };
                return r;
            }
            else
            {
                var res = localReport.Execute(RenderType.Excel, extention, perameter, mimetype);


                // return File(res.MainStream, "application/msexcel");
                r.Data = Convert.ToBase64String(res.MainStream, 0, res.MainStream.Length);
                r.Status = true;
                r.Message = new List<string>() { "Excel!" };
                return r;
            }
        }
    }
}
