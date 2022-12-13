using Dapper;
using Medical_App_1.Server.Factory;
using Medical_App_1.Server.Repository;
using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.Medical;
using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Medical_App_1.Server.Services.Medical.SqlServerClass
{
    public class MedicineService : RepositoryBase, IMedicineService
    {
        public MedicineService(IConnectionFactoryAuthDB connectionFactoryAuthDB, IConnectionFactoryMedicalDB connectionFactoryMedicalDB) : base(connectionFactoryAuthDB, connectionFactoryMedicalDB)
        {

        }
        public async Task<Result<List<Medicine>>> SelectAll()
        {

            Result<List<Medicine>> r = new Result<List<Medicine>>();
            try
            {
                var Output = await ConnectionMedicalDB.QueryAsync<Medicine>("select top 1 * from Item");
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
               
                var p = new DynamicParameters();
                p.Add("@MBox", model.MBox);
                p.Add("@MId", model.MId);
                var Output = await ConnectionMedicalDB.ExecuteAsync("update Item set MBox=@MBox where MId=@MId", p);
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

               
                //var p = new DynamicParameters();
                //p.Add("@MName", MName);

                var Output = await ConnectionMedicalDB.QueryAsync<ListItems>("SELECT top 10 MId as Value, SMedicine as Text FROM Medical.MSelectMedicine where SMedicine Like '" + SMedicine + "%' ");
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
              
                var p = new DynamicParameters();
                p.Add("@SMedicine", SMedicine);
                var Output = await  ConnectionMedicalDB.QueryAsync<Medicine>("select * from Medical.MSelectMedicine where SMedicine=@SMedicine", p);

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
                
                var p = new DynamicParameters();
                p.Add("@MName", model.MName);
                p.Add("@MUnit", model.MUnit);
                p.Add("@MCN", model.MCN);
                p.Add("@MRate", model.MRate);
                p.Add("@MMRP", model.MMRP);
                p.Add("@MVAT", model.MVAT);
                p.Add("@MBox", model.MBox);
                p.Add("@MId", model.MId);

                var Output = await ConnectionMedicalDB.ExecuteAsync("update Item set MName=@MName,MUnit=@MUnit,MCN=@MCN,MRate=@MRate,MMRP=@MMRP,MVAT=@MVAT,MBox=@MBox where MId=@MId", p);
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
                var Output = await ConnectionMedicalDB.ExecuteAsync("insert into   Item(MName,MUnit,MCN,MRate,MMRP,MVAT,MBox) values(@MName,@MUnit,@MCN,@MRate,@MMRP,@MVAT,@MBox)", p);
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
           
            Result<int> r = new Result<int>();
            try
            {
                var p = new DynamicParameters();

                p.Add("@MId", MId);
                var Output = await ConnectionMedicalDB.ExecuteAsync("delete *from Item where MId=@MId", p);
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
