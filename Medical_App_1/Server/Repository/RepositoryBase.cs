
using Medical_App_1.Server.Factory;
using System;
using System.Data;

namespace Medical_App_1.Server.Repository
{
   
    public abstract class RepositoryBase : IRepository
    {
       
        protected IDbConnection ConnectionAuthDB;
        protected IDbConnection ConnectionMedicalDB;

        private bool _disposed;

       
        protected RepositoryBase(IConnectionFactoryAuthDB connectionFactoryAuthDB, IConnectionFactoryMedicalDB connectionFactoryMedicalDB)
        {
            try
            {
                ConnectionAuthDB = connectionFactoryAuthDB.GetConnection;
                ConnectionMedicalDB = connectionFactoryMedicalDB.GetConnection;
                //Not required to open the connection, it will automatically managed by DAPPER
                //Connection.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }        

       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

             private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ConnectionAuthDB?.Dispose();
                    ConnectionMedicalDB?.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="RepositoryBase{TEntity}"/> class.
        /// </summary>
        ~RepositoryBase()
        {
            Dispose(false);
        }
    }

    
}
