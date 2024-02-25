using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    
    public class OrderItem
    {
        //[PrimaryKey("OrderItemId", "OederOrderI")]
        public int Id { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        // Navigation Properties
        public virtual Product Product  {  get; set; }
        public virtual Order Order {get;set;}
    }
}
