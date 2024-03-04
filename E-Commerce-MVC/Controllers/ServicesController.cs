using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
	public class ServicesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
