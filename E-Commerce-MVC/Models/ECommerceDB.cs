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
