using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime Date { set; get; }
        [Column(TypeName ="money")]
        public decimal Price { set; get; }
        [ForeignKey("Customer")]
        public int? CustomerId { set; get; }
        [ForeignKey("Payment")]
        public int? PaymentId { set; get; }
        [ForeignKey("Shipment")]
        public int? ShipmentId { set; get; }

        // Navigation Properties
        public virtual Shipment Shipment  { set; get; }
        public virtual Payment Payment  { set; get; }
        public virtual Customer Customer { set; get; }

        public virtual List<OrderItem> OrderItems { set; get; } = new List<OrderItem>();
    }
}
