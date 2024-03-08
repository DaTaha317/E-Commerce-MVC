using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    public class CartItem
    {
        public int Quantity { get; set; }

        [ForeignKey("customer")]
        public string? CustomerId { get; set; }

        [ForeignKey("product")]
        public int? ProductId { get; set; }

        // Navigation Properties
        public virtual User customer { get; set; }

        public virtual Product product { get; set; }

    }
}
