using Microsoft.EntityFrameworkCore;

namespace E_Commerce_MVC.Models
{
    public class ECommerceDB : DbContext
    {
        public virtual DbSet<CartItem> CartItems { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

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
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.PhoneNumber).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
