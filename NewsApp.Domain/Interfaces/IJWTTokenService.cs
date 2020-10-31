using NewsApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Domain.Interfaces
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);
    }
}
