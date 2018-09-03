using System;
using System.Collections.Generic;
using System.Text;
using FSP.Core.Domain.Entities;

namespace FSP.Core.Domain.Repositories
{
    public interface IRepository<TEntity>:IRepository<TEntity,int> where TEntity : class, IEntity<int>
    {
    }
}
