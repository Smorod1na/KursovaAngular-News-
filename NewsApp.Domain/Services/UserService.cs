using NewsApp.DAL.Entity;
using NewsApp.DAL.Repository.Abstraction;
using NewsApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserAdditional> _userRepo;
        public UserService(IGenericRepository<UserAdditional> userRepo)
        {
            _userRepo = userRepo;
        }
        public void editUser(UserAdditional user)
        {
            _userRepo.Update(user);
        }
    }
}
