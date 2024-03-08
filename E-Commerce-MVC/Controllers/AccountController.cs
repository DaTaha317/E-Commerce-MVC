using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<User> userManager;
		private SignInManager<User> signInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
		}
        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM login)
		{
			if (ModelState.IsValid)
			{
				User user = await userManager.FindByEmailAsync(login.Email);

				if (user != null)
				{
					bool found = await userManager.CheckPasswordAsync(user, login.Password);

					if (found)
					{
						await signInManager.SignInAsync(user, isPersistent: false);
						return RedirectToAction("Index", "Home");
					}
				}
				ModelState.AddModelError("", "Wrong Email or password");
			}
			return View(login);
		}

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
