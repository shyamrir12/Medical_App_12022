using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Factory
{
   public interface IConnectionFactoryMedicalDB
    {
        IDbConnection GetConnection { get; }
    }
}
