using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
	[Authorize(Roles = "admin")]
	public class RoleController : Controller
	{
		private RoleManager<IdentityRole> roleManager;

		public RoleController(RoleManager<IdentityRole> roleManager)
        {
			this.roleManager = roleManager;
		}
        public IActionResult Index()
		{
			List<IdentityRole> roles = roleManager.Roles.ToList();
			return View(roles);
		}

		[HttpGet]
		public IActionResult add()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> add(IdentityRole role)
		{
			if (ModelState.IsValid)
			{
				IdentityResult result = await roleManager.CreateAsync(role);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View(role);
		}
	}
}
