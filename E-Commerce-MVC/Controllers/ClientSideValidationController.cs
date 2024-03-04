using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace E_Commerce_MVC.Controllers
{
	public class ClientSideValidationController : Controller
	{
		public IActionResult fNameLength(string FirstName)
		{
			if (FirstName.Length < 4 || FirstName.Length > 50)
			{
				return Json(false);
			}
			else
			{
				return Json(true);
			}
		}


		public IActionResult lNameLength(string LastName)
		{
			if (LastName.Length < 4 || LastName.Length > 50)
			{
				return Json(false);
			}
			else
			{
				return Json(true);
			}
		}


		public IActionResult phoneLength(string Phone)
		{
			if (Phone.Length != 11)
			{
				return Json(false);
			}
			else
			{
				return Json(true);
			}
		}


		public IActionResult emailValidator(string EmailAddress)
		{

			string pattern = @"(^\w+@.+)";
			Regex re = new Regex(pattern);


			if (re.IsMatch(EmailAddress))
			{
				return Json(true);
			}
			else
			{
				return Json(false);
			}

		}


	}
}
