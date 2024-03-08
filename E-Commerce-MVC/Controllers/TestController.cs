using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_MVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Content(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
