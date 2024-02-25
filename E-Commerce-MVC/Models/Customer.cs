using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace E_Commerce_MVC.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime JoinDate { get; set; }


        public virtual List<Cart> Carts { get; set; } = new List<Cart>();

        public virtual List<Payment> Payments { get; set; } = new List<Payment>();

        public virtual List<Order> Orders { get; set; } = new List<Order>();

        public virtual List<Shipment> Shipments { get; set; } = new List<Shipment>();

    }
}
