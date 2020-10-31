using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.DAL
{
   public class EFContext:IdentityDbContext<User>
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
        public DbSet<News> News { get; set; }
        public DbSet<UserAdditional> UserAdditional { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Categori> Categori { get; set; }

        public DbSet<UserIsFavorite> UserIsFavorites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().
                HasOne(x => x.UserAdditional)
                .WithOne(y => y.User)
                .HasForeignKey<UserAdditional>(z => z.Id); //звязок один до одного


            base.OnModelCreating(builder);
        }
    }
}
