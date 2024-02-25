using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    public class Cart
    {

        public int Id { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }


        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

    }
}
