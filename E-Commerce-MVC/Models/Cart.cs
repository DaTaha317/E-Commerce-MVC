namespace E_Commerce_MVC.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }

    }
}
