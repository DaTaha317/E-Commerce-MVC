﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_Commerce_MVC.ViewModels;

namespace E_Commerce_MVC.Models
{
    public class ECommerceDB : IdentityDbContext<User>
    {
        public virtual DbSet<CartItem> CartItems { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<User> Customers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Shipment> Shipments { get; set; }

        // Constructor overloading to allow for IoC injection of ECommerceDB context
        public ECommerceDB() : base() { } 
        public ECommerceDB(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite primary key for CartItems
            modelBuilder.Entity<CartItem>().HasKey(c => new
            {
                c.ProductId,
                c.CustomerId
            });

            // composite primary key for OrderItems
            modelBuilder.Entity<OrderItem>().HasKey(o => new
            {
                o.ProductId,
                o.OrderId
            });

            // Unique attribute for Customer Email & Phone number
            modelBuilder.Entity<User>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(c => c.PhoneNumber).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<E_Commerce_MVC.ViewModels.CustomerVM> CustomerVM { get; set; } = default!;
        public DbSet<E_Commerce_MVC.ViewModels.LoginVM> LoginVM { get; set; } = default!;
        public DbSet<E_Commerce_MVC.ViewModels.AdminVM> AdminVM { get; set; } = default!;
        public DbSet<E_Commerce_MVC.ViewModels.ProductVM> ProductVM { get; set; } = default!;
    }
}
