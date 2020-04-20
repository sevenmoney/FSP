using System;
using System.Collections.Generic;
using System.Text;
using FSP.Core.Domain.Entities;
using FSP.Datas.EfCore.ContextProvider;
using FSP.Datas.EfCore.Repositories;

namespace Data.Repositories
{
    public class SampleRepositoryBase<TEntity,TPrimaryKey>: EfRepositoryBase<SampleDbContext, TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>{
        public SampleRepositoryBase(IDbContextProvider<SampleDbContext> dbContextProvider) : base(dbContextProvider){

        }

        //todo 公共的仓储方法
    }
}
