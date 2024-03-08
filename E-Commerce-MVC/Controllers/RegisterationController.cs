using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class RegisterationController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public RegisterationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
        public async Task<IActionResult> Register(CustomerVM customerVM)
        {
            User user = new User
            {
                UserName = customerVM.Email,
                Email = customerVM.Email,
                PasswordHash = customerVM.Password,
                FirstName = customerVM.FirstName,
                LastName = customerVM.LastName,
                Address = customerVM.Address,
                PhoneNumber = customerVM.PhoneNumber,
            };

            IdentityResult result = await userManager.CreateAsync(user, customerVM.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }
    }
}
