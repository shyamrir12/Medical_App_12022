﻿
namespace Medical_App_1.Server.ServerModels
{
    /// <summary>
    /// Interface IEntity
    /// </summary>
    public interface IEntity
    {
    }
    
    public abstract class BaseEntity : IEntity
    {
    }
    
    public abstract class BaseEntity<T> : BaseEntity, IEntity
    {
       
        public abstract T Key { get; set; }
    }

}
