using Microsoft.EntityFrameworkCore;

/*
 1. composite key in Cart

 */

namespace E_Commerce_MVC.Models
{
    public class ECommerceDB : DbContext
    {
        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Shipment> Shipments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.;Database=ECommerceDB;Integrated Security=True;TrustServerCertificate=True;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite primary key for Cart
            modelBuilder.Entity<Cart>().HasKey(c => new
            {
                c.Id,
                c.CustomerId
            });

            // composite primary key for OrderItems
            modelBuilder.Entity<OrderItem>().HasKey(o => new
            {
                o.Id,
                o.OrderId
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
