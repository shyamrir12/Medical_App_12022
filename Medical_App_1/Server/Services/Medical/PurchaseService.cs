using Dapper;
using Medical_App_1.Server.Services.Medical.Interfaces;
using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Services.Medical
{
    public class PurchaseService: IPurchaseService
    {
        public readonly IOptions<Keylist> _objKeyList;
        string ConStr = "";

        public PurchaseService(IOptions<Keylist> objKeyList)
        {
            ConStr = objKeyList.Value.LocalDBConnectionString;

        }
        public async Task<Result<List<ListItems>>> SelectBillNoList(string  PurchaseType)
        {

            Result<List<ListItems>> r = new Result<List<ListItems>>();
            try
            {
                using var connection = new SqliteConnection(ConStr);
                var p = new DynamicParameters();
                p.Add("@PurchaseType", PurchaseType);
                var Output = await connection.QueryAsync<ListItems>("SELECT Purchase.BillNo as Value, Purchase.BillNo as Text FROM Purchase where PurType=@PurchaseType", p);

                if (Output.Count() > 0)
                {

                    r.Data = Output.ToList(); 
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

        public async Task<Result<List<ListItems>>> SelectSuplierList(string AccountType)
        {

            Result<List<ListItems>> r = new Result<List<ListItems>>();
            try
            {
                using var connection = new SqliteConnection(ConStr);
                var p = new DynamicParameters();
                p.Add("@AccountType", AccountType);
                var Output = await connection.QueryAsync<ListItems>("SELECT Suplier.SupId as Value, Suplier.SupName as Text FROM Suplier where AccountType=@AccountType", p);

                if (Output.Count() > 0)
                {

                    r.Data = Output.ToList();
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
        public async Task<Result<Purchase>> SelectIPurchaseByBill(string BillNo)
        {

            Result<Purchase> r = new Result<Purchase>();
            try
            {
                using var connection = new SqliteConnection(ConStr);
                var p = new DynamicParameters();
                p.Add("@BillNo", BillNo);
                var Output = await connection.QueryAsync<Purchase>("SELECT Purchase.BillNo, Purchase.Purdate, Purchase.SupId, Purchase.ValueOfGood, Purchase.Descount, Purchase.Vat, Purchase.TotalAmount, Purchase.NetAmount FROM Purchase WHERE Purchase.BillNo=@BillNo", p);

                if (Output.Count() > 0)
                {

                    r.Data = Output.FirstOrDefault();

                    var OutputList = await connection.QueryAsync<PurchaseItem>("SELECT PurchaseItem.SNo, PurchaseItem.MName , PurchaseItem.Stri, PurchaseItem.Tab, PurchaseItem.Disc, PurchaseItem.Free,PurchaseItem.Vat as GST,  PurchaseItem.ExpDate, PurchaseItem.BatchNo, PurchaseItem.DescA, PurchaseItem.VatA , PurchaseItem.Rate,PurchaseItem.MRP, PurchaseItem.Amount, PurchaseItem.PurItemId, PurchaseItem.MId, PurchaseItem.PurId FROM PurchaseItem WHERE PurchaseItem.PurId=@BillNo order by PurchaseItem.SNo", p);
                    if (OutputList.Count() > 0)
                    {

                        r.Data.PurchaseItemList = OutputList.ToList();
                      
                    }


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
