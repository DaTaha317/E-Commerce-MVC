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
        public IActionResult Index(string SearchText = "")
        {
            List<Product> products;

            if (SearchText != "" && SearchText != null)
            {
                products = context.GetAll(SearchText);
            }
            else
            {
                products = context.GetAll();
			}

            return View(products);
        }
    }
}
