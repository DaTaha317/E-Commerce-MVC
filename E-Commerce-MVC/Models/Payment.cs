using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [ForeignKey("customer")]
        public string? CustomerId { get; set; }

        // Navigation Properties
        public virtual User customer { get; set; }
        public virtual List<Order> orders { get; set; } = new List<Order>();

    }
}
