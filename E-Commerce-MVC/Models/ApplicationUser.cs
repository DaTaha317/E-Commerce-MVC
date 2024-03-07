using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_MVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        // Navigation Properties
        public virtual Customer? Customer { get; set; }
    }
}
