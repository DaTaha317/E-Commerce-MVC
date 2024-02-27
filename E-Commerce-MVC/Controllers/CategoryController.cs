using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepo context;
        public CategoryController(ICategoryRepo context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Category> category = context.GetAll();
            return View(category);
        
        }
    }
}
