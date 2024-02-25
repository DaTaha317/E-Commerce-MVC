using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime Date { set; get; }
        [Column(TypeName ="money")]
        public decimal Price { set; get; }
        //[ForeignKey("customer")]
        public int? CustomerId { set; get; }
        //[ForeignKey("payment")]
        public int? PaymentId { set; get; }
        //[ForeignKey("customer")]
        public int? ShipmentId { set; get; }

        // Navigation Properties
        //public virtual Shipment shipm  { set; get; }
        //public virtual Payment payment  { set; get; }
        //public virtual Customer customer  { set; get; }
        public virtual List<OrderItem> OrderItems { set; get; }=new List<OrderItem>();
    }
}
