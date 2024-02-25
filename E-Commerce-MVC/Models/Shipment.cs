using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
   
    public class Shipment
    {
        
        public int Id { get; set; }
        public DateTime ShipmentDate { get;set; }
        public string Address { get;set; }
        public string City { get; set; }  
        public string State { get;set; } 
        
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public ShipmentStatus Status { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
