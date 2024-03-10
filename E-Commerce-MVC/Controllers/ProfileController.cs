using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_MVC.Controllers
{
	[Authorize]
	public class ProfileController : Controller
	{
		private ICustomerRepo context;

		public ProfileController(ICustomerRepo context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = context.GetById(customerId);
			return View(user);
		}
	}
}
