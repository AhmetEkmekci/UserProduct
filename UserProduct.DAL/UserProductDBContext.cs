using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserProduct.DAL.Entity;

namespace UserProduct.DAL
{
    public class UserProductDBContext : DbContext
    {
        public UserProductDBContext(DbContextOptions<UserProductDBContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    IdentityNumber = "11111111111",
                    FirstName = "Ahmet",
                    LastName = "Ekmekci",
                    PhoneNumber = "5555555555",
                    EMailAddress = "test@test.test",
                },
                new User()
                {
                    Id = 2,
                    IdentityNumber = "22222222222",
                    FirstName = "XXX",
                    LastName = "YYY",
                    PhoneNumber = "5445555555",
                    EMailAddress = "testtest@test.test",
                }
            );

            modelBuilder.Entity<Product>().HasData(
               Enumerable.Range(1, 15).Select(x => new Product()
               {
                   Id = x,
                   Name = $"P{x}",
                   Price = 11.33M + x,
                   Description = $"P{x} Description...",
               })
            );

            modelBuilder.Entity<Cart>().HasOne(x => x.Product).WithMany().HasForeignKey(x=>x.ProductId);
            modelBuilder.Entity<Cart>().HasOne(x => x.User).WithMany(x => x.Cart).HasForeignKey(x => x.UserId);

        }
    }
}
