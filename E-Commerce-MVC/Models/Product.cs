using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Commerce_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        [ForeignKey("category")]
        public int? CategoryId { get; set; }

        // Navigation Properties
        public virtual Category category { get; set; }

        public virtual List<OrderItem> orderItems { get; set; }
        public virtual List<CartItem> cartItems { get; set; }
    }
}
