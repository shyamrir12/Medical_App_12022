using Dapper;
using Medical_App_1.Server.Factory;
using Medical_App_1.Server.Repository;
using Medical_App_1.Server.Services.Medical.Interfaces;
using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Services.Medical.SqlServerClass
{
    public class PuurchaseServiceSQLServer : RepositoryBase, IPurchaseService
    {

        public PuurchaseServiceSQLServer(IConnectionFactoryAuthDB connectionFactoryAuthDB, IConnectionFactoryMedicalDB connectionFactoryMedicalDB) : base(connectionFactoryAuthDB, connectionFactoryMedicalDB)
        {

        }

        public async Task<Result<List<ListItems>>> SelectBillNoList(string PurchaseType)
        {

            Result<List<ListItems>> r = new Result<List<ListItems>>();
            try
            {
                
                var p = new DynamicParameters();
                p.Add("@PurchaseType", PurchaseType);
                var Output = await ConnectionMedicalDB.QueryAsync<ListItems>("SELECT BillNo as Value, BillNo as Text FROM Medical.Purchase where PurType=@PurchaseType", p);

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
               
                var p = new DynamicParameters();
                p.Add("@AccountType", AccountType);
                var Output = await ConnectionMedicalDB.QueryAsync<ListItems>("SELECT SupId as Value, SupName as Text FROM Medical.UserAccount where AccountType=@AccountType", p);

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

                var p = new DynamicParameters();
                p.Add("@BillNo", BillNo);
                var Output = await ConnectionMedicalDB.QueryAsync<Purchase>("SELECT BillNo,Purdate, SupId, ValueOfGood, Descount, Vat, TotalAmount, NetAmount FROM Medical.Purchase WHERE BillNo=@BillNo", p);
               

                if (Output.Count() > 0)
                {

                    r.Data = Output.FirstOrDefault();

                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = null;
                    r.Status = false;
                    r.Message = new List<string>() { "Failed!" };

                }

                var OutputList = await ConnectionMedicalDB.QueryAsync<PurchaseItem>("SELECT SNo,MName , Stri, Tab, Disc, Free,Vat as GST, ExpDate,BatchNo, DescA, VatA , Rate,MRP, Amount,PurItemId,MId,PurId FROM  Medical.PurchaseItem WHERE PurId=@BillNo order by SNo", p);
                if (OutputList.Count() > 0)
                {

                    r.Data.PurchaseItemList = OutputList.ToList();

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
