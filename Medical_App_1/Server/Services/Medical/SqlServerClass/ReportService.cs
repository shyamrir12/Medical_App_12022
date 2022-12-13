using Dapper;
using Medical_App_1.Server.Factory;
using Medical_App_1.Server.Repository;
using Medical_App_1.Server.Services.Medical.Interfaces;
using Medical_App_1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Services.Medical.SqlServerClass
{
    public class ReportService : RepositoryBase, IReportService
    {
        public ReportService(IConnectionFactoryAuthDB connectionFactoryAuthDB, IConnectionFactoryMedicalDB connectionFactoryMedicalDB) : base(connectionFactoryAuthDB, connectionFactoryMedicalDB)
        {

        }
        public async Task<Result<DataSet>> SelectPurchaseSingleReport(string BillNo)
        {
            Result<DataSet> r = new Result<DataSet>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@BillNo", BillNo);
                var result = await ConnectionMedicalDB.ExecuteReaderAsync("select * from [Medical].[RSelctPurchase] WHERE BillNo=@BillNo", p);
                var ds = Utility.ConvertDataReaderToDataSet(result);

              
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {

                    r.Data = ds;
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = null;
                    r.Status = false;
                    r.Message = new List<string>() { "Failed!" };

                }
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            return r;
        }
    }
}
