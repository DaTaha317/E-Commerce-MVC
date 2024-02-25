using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Commerce_MVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual List<Cart> Cart { get; set; } = new List<Cart>();
    }
}
