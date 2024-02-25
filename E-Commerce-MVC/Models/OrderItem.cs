using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    
    public class OrderItem
    {
        //[PrimaryKey("OrderItemId", "OederOrderI")]
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        //[ForeignKey("product")]
        public int ProductProd { get; set; }
        public int OederOrderI { get; set; }
        //public virtual Product product  {  get; set; }
        //public virtual Order order{get;set;}
    }
}
