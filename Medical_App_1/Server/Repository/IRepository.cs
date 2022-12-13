


using Medical_App_1.Server.ServerModels;
using System;
using System.Collections.Generic;
using System.Data;



namespace Medical_App_1.Server.Repository
{
    
    public interface IRepository : IDisposable
    {

    }
    
    public interface IRepository<out TEntity> : IRepository where TEntity : class, IEntity
    {
       
        IEnumerable<TEntity> Query(string sqlCommand, object param = null, CommandType? commandType = CommandType.Text);
    }

  
    public interface IEntityRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
       
        IEnumerable<TEntity> GetAll();
        
        TEntity Find(object key);
        
        long Add(TEntity entity);
       
        bool Update(TEntity entity);
    
        bool Delete(TEntity entity);
    }
}
