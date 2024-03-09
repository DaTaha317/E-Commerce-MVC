using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace E_Commerce_MVC.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public DateTime JoinDate { get; set; }

        // Navigation Properties
        public virtual List<CartItem> cartItems { get; set; } = new List<CartItem>();

        public virtual List<Payment> payments { get; set; } = new List<Payment>();

        public virtual List<Order> orders { get; set; } = new List<Order>();

        public virtual List<Shipment> shipments { get; set; } = new List<Shipment>();

    }
}
