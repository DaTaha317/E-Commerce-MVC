using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepo context;

        public ProductController(IProductRepo context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Product> products = context.GetAll();
            return View(products);
        }
    }
}
