using System;
using System.Collections.Generic;
using Core.Entities;
using FSP.Core.Domain.Repositories;

namespace Core.IRepositories{
    public interface IUserRepository: IRepository<User,Guid>{
    }
}