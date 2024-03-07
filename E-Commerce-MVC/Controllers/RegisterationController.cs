using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class RegisterationController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public RegisterationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
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

        //[HttpPost]
        //public async Task<IActionResult> Register(CustomerVM customerVM)
        //{
        //    ApplicationUser user = new ApplicationUser
        //    {
        //        Email = customerVM.Email,
        //        PasswordHash = customerVM.Password
        //    };
            
        //    return View();
        //}
    }
}
