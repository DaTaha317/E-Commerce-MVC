using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime Date { set; get; }
        [Column(TypeName ="money")]
        public decimal Price { set; get; }
        [ForeignKey("customer")]
        public string? CustomerId { set; get; }
        [ForeignKey("payment")]
        public int? PaymentId { set; get; }
        [ForeignKey("shipment")]
        public int? ShipmentId { set; get; }

        // Navigation Properties
        public virtual Shipment shipment  { set; get; }
        public virtual Payment payment  { set; get; }
        public virtual User customer { set; get; }

        public virtual List<OrderItem> orderItems { set; get; } = new List<OrderItem>();
    }
}
