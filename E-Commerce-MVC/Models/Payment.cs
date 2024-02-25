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
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
