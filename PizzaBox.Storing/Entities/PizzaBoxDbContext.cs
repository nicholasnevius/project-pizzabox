using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public class AnimalsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=tcp:<server>.database.windows.net,1433;Initial Catalog=<DB>;User ID=<user>;Password=<Password>");
        }

        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Topping>(topping => topping.HasIndex(t => t.ToppingType).IsUnique());
            //modelBuilder.Entity<Crust>(crust => crust.HasIndex(c => c.CrustType).IsUnique());
            //modelBuilder.Entity<Store>(store => store.HasIndex(s => s.Name).IsUnique());
            //modelBuilder.Entity<Size>(size => size.HasIndex(s => s.SizeType).IsUnique());
            //modelBuilder.Entity<Customer>(customer => customer.HasIndex(c => c.Name).IsUnique());

            base.OnModelCreating(modelBuilder);
        }


    }
}