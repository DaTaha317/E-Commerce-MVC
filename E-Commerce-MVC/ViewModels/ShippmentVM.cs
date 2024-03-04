using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_MVC.ViewModels
{
    public class ShippmentVM
    {
        [Required]
        public string Country { get; set; }



        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone must should contain 11 numbers")]
		[Remote("phoneLength", "ClientSideValidation", ErrorMessage = "enter only 11 numbers")]
		public string Phone { get; set; }


        [Required(ErrorMessage = "Email Address is required")] // emailValidator
		[Remote("emailValidator", "ClientSideValidation", ErrorMessage = "enter a valid email")]
		[EmailAddress(ErrorMessage = "You should provide a valid email address")]
        public string EmailAddress { get; set; }


        public DateTime Date { get; set; }

        [Required]
        [Length(5,20,ErrorMessage = "You should provide at least 5 characters")]
        public string Address { get; set; }


        public string AddressDetails { get; set; }

        [Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string City { get; set; }

        [Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string State { get; set; }

        [Required]
        [StringLength(5,MinimumLength = 5,ErrorMessage = "zip code should be 5 numbers")]
        public string ZipCode { get; set; }

    }
}
