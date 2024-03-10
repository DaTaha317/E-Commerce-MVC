using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
   
    public class Shipment
    { 
        public int Id { get; set; }
        public DateTime Date { get;set; }
        public string Address { get;set; }
        public string City { get; set; }  
        public string State { get;set; } 
        
        public string Country { get; set; }
        [Display(Name = "Zip Code")]

        public string ZipCode { get; set; }
        public ShipmentStatus Status { get; set; }
        [ForeignKey("customer")]
        public string? CustomerId { get; set; }

        // Navigation Properties
        public virtual User customer { get; set; }

        public virtual List<Order> orders { get; set; } = new List<Order>();
    }
}
