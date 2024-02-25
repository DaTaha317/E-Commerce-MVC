using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Commerce_MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal ? Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
