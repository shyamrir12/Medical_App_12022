using Medical_App_1.Server.Factory;
using Medical_App_1.Server.Repository;
using Medical_App_1.Server.Services.Medical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Services.Medical.SqlServerClass
{
    public class SalesService : RepositoryBase, ISalesService
    {
        public SalesService(IConnectionFactoryAuthDB connectionFactoryAuthDB, IConnectionFactoryMedicalDB connectionFactoryMedicalDB) : base(connectionFactoryAuthDB, connectionFactoryMedicalDB)
        {

        }
    }
}
