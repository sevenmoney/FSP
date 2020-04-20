using System;
using System.Collections.Generic;
using Application.Users.Dto;
using Core.Entities;
using Core.IRepositories;
using FSP.Core.Domain.Repositories;

namespace Application.Users{
    public class UserService : IUserService{
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository){
            _userRepository = userRepository;
        }
        public List<UserDto> GetUsers(){
            var list = new List<UserDto>();
            var query = _userRepository.GetAll();
            foreach (var item in query)
                list.Add(new UserDto{
                    UserName = item.UserName,
                    UserAddress = item.UserAddress
                });
            return list;
        }
    }
}