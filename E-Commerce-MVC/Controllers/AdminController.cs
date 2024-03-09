using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
	[Authorize(Roles ="admin")]
	public class AdminController : Controller
	{
		private UserManager<User> userManager;

		public AdminController(UserManager<User> userManager)
        {
			this.userManager = userManager;
		}
        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(AdminVM adminVM)
		{
			User admin = new User
			{
				UserName = adminVM.Email,
				Email = adminVM.Email,
				PasswordHash = adminVM.Password,
				JoinDate = DateTime.Now
			};

			IdentityResult result = await userManager.CreateAsync(admin, adminVM.Password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(admin, "Admin");
				return RedirectToAction("Index");
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
			return View();
		}
	}
}
