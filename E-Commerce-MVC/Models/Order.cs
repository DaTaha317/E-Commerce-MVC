using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    public class Order
    {
        public int OrderId { set; get; }
        public DateTime OrderDate { set; get; }
        [Column(TypeName ="money")]
        public decimal OrderPrice { set; get; }
        //[ForeignKey("customer")]
        public int CustomeCusto { set; get; }
        //[ForeignKey("payment")]
        public int PaymentPayme { set; get; }
        //[ForeignKey("customer")]
        public int ShipmentShipm { set; get; }
        //public virtual Shipment shipm  { set; get; }
        //public virtual Payment payment  { set; get; }
        //public virtual Customer customer  { set; get; }
        public virtual List<OrderItem> OrderItems { set; get; }=new List<OrderItem>();
    }
}
