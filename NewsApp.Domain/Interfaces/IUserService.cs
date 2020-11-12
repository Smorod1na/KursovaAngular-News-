using NewsApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Interfaces
{
   public interface IUserService
    {
        void editUser(UserAdditional user);
        void deleteUser(UserAdditional user);

    }
}
