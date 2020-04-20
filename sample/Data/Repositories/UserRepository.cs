using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entities;
using Core.IRepositories;
using FSP.Datas.EfCore.ContextProvider;

namespace Data.Repositories
{
    public class UserRepository:SampleRepositoryBase<User,Guid>,IUserRepository
    {
        public UserRepository(IDbContextProvider<SampleDbContext> dbContextProvider) : base(dbContextProvider){

        }
        //todo 自定义仓储方法
        public IQueryable<User> Test(){
            return GetAll();
        }
    }
}
