
using Dapper;
using Medical_App_1.Server.Factory;
using Medical_App_1.Server.Repository;
using Medical_App_1.Server.Services.UserManage.Interfaces;
using Medical_App_1.Shared.Models.UserModels;
using Medical_App_1.Shared.Models.Medical;
using System.Collections.Generic;
using System.Data;

using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;


namespace Medical_App_1.Server.Services.UserManage
{
    public class UserService : RepositoryBase, IUserService
    {


        public UserService(IConnectionFactoryAuthDB connectionFactoryAuthDB, IConnectionFactoryMedicalDB connectionFactoryMedicalDB) : base(connectionFactoryAuthDB, connectionFactoryMedicalDB)
        {

        }
        public async Task<User> Authenticate(string EmailAddress, string password)
        {
            User _user = new User();
            var p = new DynamicParameters();
            p.Add("@EmailAddress", EmailAddress);
            p.Add("@password", password);
            //select the role from database
       
            var Output = await ConnectionAuthDB.QueryAsync<User>("SELECT User_Master.UserID, User_Master.RoleId, User_Master.subroleid, User_Master.Name, User_Master.OrganizationName, User_Master.EmailId, User_Master.Mobile_No, User_Master.Username, User_Master.Password, User_Master.CreateDate, User_Master.Ipaddress, User_Master.loginattempt, User_Master.Activation, User_Master.logindate, User_Master.Designation, User_Master.photo, User_Master.Deptid, Role_Master.RoleDesc AS Role FROM   Role_Master INNER JOIN User_Master ON Role_Master.RoleID = User_Master.RoleId WHERE(User_Master.EmailId = @EmailAddress) AND(User_Master.Password = @password)", p);
            if (Output.Count() > 0)
            {

                _user = Output.FirstOrDefault();

            }

            // return null if user not found
            if (_user == null)
                return null;

            // authentication successful so return user details without password
            _user.Password = null;
            return _user;
        }

        public async Task<List<User>> GetAll()
        {
            // return users without passwords

            // Proc_Get_All_User
            List<User> _userlist = new List<User>();
            var Output = await ConnectionAuthDB.QueryAsync<User>("Proc_Get_All_User", commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                _userlist = Output.ToList();

            }
            return _userlist;
        }

        public async Task<User> GetUserById(string UserId)
        {
            User _user = new User();
            var p = new DynamicParameters();

            p.Add("@UserID", UserId);

            //select the role from database
            var Output = await ConnectionAuthDB.QueryAsync<User>("Proc_Get_User_By_Id", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                _user = Output.FirstOrDefault();

            }
            //_user.UserId = 2;
            //_user.EmailAddress = "avnish@gmail.com";
            _user.Password = null;

            return _user;
        }


    }
}
