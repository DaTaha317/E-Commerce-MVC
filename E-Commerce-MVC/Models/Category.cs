using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Commerce_MVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // Navigation Properties
        public virtual List<Product> products { get; set; } = new List<Product>();

    }
}
