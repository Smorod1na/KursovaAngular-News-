using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsApp.DAL;
using NewsApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.UI.Helper
{
    public class SeederDB
    {
        public static void SeedData(IServiceProvider services,
         IWebHostEnvironment env,
         IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFContext>();
                SeedUsers(manager, managerRole, context);
            }
        }
        private static void SeedUsers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            EFContext _eFContext)
        {


            var roleName = "Admin";
            if (roleManager.FindByNameAsync(roleName).Result == null)
            {
                var resultAdminRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                }).Result;
                var resultUserRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = "User"
                }).Result;
                var resultManagerRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Manager"
                }).Result;



                string email = "admin@gmail.com";
                var admin = new User
                {
                    Email = email,
                    UserName = email
                };
                var test = new User
                {
                    Email = "lozovitskii1991@gmail.com",
                    UserName = "lozovitskii1991@gmail.com"
                };

                var resultAdmin = userManager.CreateAsync(admin, "Qwerty1-").Result;
                resultAdmin = userManager.AddToRoleAsync(admin, "Admin").Result;

                var resultUser = userManager.CreateAsync(test, "Qwerty1-").Result;
                resultUser = userManager.AddToRoleAsync(test, "User").Result;

            }


        }
    }
}
