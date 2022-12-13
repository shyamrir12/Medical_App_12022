using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical_App_1.Shared.Models.Medical;
using Microsoft.Extensions.Options;

using Medical_App_1.Server.ServerModels;
using Medical_App_1.Shared.Models;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;


namespace Medical_App_1.Server.Services.Medical
{
    public class MedicineServiceADC : IMedicineService
    {
        public readonly IOptions<Keylist> _objKeyList;
        //OleDbConnection con;
        //OleDbCommand cmd;

        string ConStr = "";

        //public string ConStr =  "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = CHEMIST_SHOP1.mdb;Jet OLEDB:Database Password = sbtech";
        public MedicineServiceADC(IOptions<Keylist> objKeyList)
        {
            ConStr = objKeyList.Value.LocalDBConnectionString;

        }
        public async Task<Result<List<Medicine>>> SelectAll()
        {

            Result<List<Medicine>> r = new Result<List<Medicine>>();
            try
            {
                using var connection = new SqliteConnection(ConStr);
                var Output = await connection.QueryAsync<Medicine>("select * from Item LIMIT 1");
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
        public async Task<Result<int>> UpdateBox(Medicine model)
        {

            Result<int> r = new Result<int>();
            try
            {
                using var connection = new SqliteConnection(ConStr);
                var p = new DynamicParameters();
                p.Add("@MBox", model.MBox);
                p.Add("@MId", model.MId);
                var Output = await connection.ExecuteAsync("update Item set MBox=@MBox where MId=@MId", p);
                if (Output > 0)
                {
                    r.Data = 1;
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = 0;
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
        public async Task<Result<List<ListItems>>> SelectItemCallection(string SMedicine)
     {
            Result<List<ListItems>> r = new Result<List<ListItems>>();
            try
            {
                using var connection = new SqliteConnection(ConStr);
                //var p = new DynamicParameters();
                //p.Add("@MName", MName);

                var Output = await connection.QueryAsync<ListItems>("SELECT MId as Value, SMedicine as Text FROM MSelectMedicine where SMedicine Like '" + SMedicine + "%' LIMIT 10 ");
                // var Output = await connection.QueryAsync<string>("SELECT SMedicine FROM MSelectMedicine");

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
        public async Task<Result<Medicine>> SelectItemCollectionSingle(string SMedicine)
        {

            Result<Medicine> r = new Result<Medicine>();
            try
            {
                using var connection = new SqliteConnection(ConStr);
                var p = new DynamicParameters();
                p.Add("@SMedicine", SMedicine);
                var Output = await connection.QueryAsync<Medicine>("select * from MSelectMedicine where SMedicine=@SMedicine", p);

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
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            return r;

        }
        public async Task<Result<int>> UpdateItem(Medicine model)
        {
            Result<int> r = new Result<int>();
            try
            {
                using var connection = new SqliteConnection(ConStr);

                var p = new DynamicParameters();
                p.Add("@MName", model.MName);
                p.Add("@MUnit", model.MUnit);
                p.Add("@MCN", model.MCN);
                p.Add("@MRate", model.MRate);
                p.Add("@MMRP", model.MMRP);
                p.Add("@MVAT", model.MVAT);
                p.Add("@MBox", model.MBox);
                p.Add("@MId", model.MId);

                var Output = await connection.ExecuteAsync("update Item set MName=@MName,MUnit=@MUnit,MCN=@MCN,MRate=@MRate,MMRP=@MMRP,MVAT=@MVAT,MBox=@MBox where MId=@MId", p);
                if (Output > 0)
                {
                    r.Data = 1;
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = 0;
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
        public async Task<Result<int>> InsertItem(Medicine model)
        {
            using var connection = new SqliteConnection(ConStr);
            Result<int> r = new Result<int>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@MName", model.MName);
                p.Add("@MUnit", model.MUnit);
                p.Add("@MCN", model.MCN);
                p.Add("@MRate", model.MRate);
                p.Add("@MMRP", model.MMRP);
                p.Add("@MVAT", model.MVAT);
                p.Add("@MBox", model.MBox);
                var Output = await connection.ExecuteAsync("insert into   Item(MName,MUnit,MCN,MRate,MMRP,MVAT,MBox) values(@MName,@MUnit,@MCN,@MRate,@MMRP,@MVAT,@MBox)", p);
                if (Output > 0)
                {
                    r.Data = 1;
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = 0;
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
        public async Task<Result<int>> DeleteItem(int MId)
        {
            using var connection = new SqliteConnection(ConStr);
            Result<int> r = new Result<int>();
            try
            {
                var p = new DynamicParameters();

                p.Add("@MId", MId);
                var Output = await connection.ExecuteAsync("delete *from Item where MId=@MId", p);
                if (Output > 0)
                {
                    r.Data = 1;
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = 0;
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
