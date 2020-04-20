using System.Collections.Generic;
using Application.Users.Dto;

namespace Application.Users{
    public interface IUserService{
        List<UserDto> GetUsers();
    }
}