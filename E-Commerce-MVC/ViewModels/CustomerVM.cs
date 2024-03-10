using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_MVC.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        [Display(Name = "Confirmed Password")]

        public string ConfirmedPassword { get; set; }
        public string Address { get; set; }
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }
    }
}
