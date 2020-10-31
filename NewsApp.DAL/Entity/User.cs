using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.DAL.Entity
{
   public class User:IdentityUser
    {
        public virtual UserAdditional UserAdditional { get; set; }
    }
}
