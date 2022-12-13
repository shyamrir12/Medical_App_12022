using Medical_App_1.Server.Factory;
using Medical_App_1.Server.Repository;
using Medical_App_1.Server.Services.UserManage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Services.UserManage
{
    public class RegisterUserService: RepositoryBase, IRegisterUserService
    {
        public RegisterUserService(IConnectionFactoryAuthDB connectionFactoryAuthDB, IConnectionFactoryMedicalDB connectionFactoryMedicalDB) : base(connectionFactoryAuthDB, connectionFactoryMedicalDB)
        {

        }
    }
}
