using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace E_Commerce_MVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepo context;

        public ProductController(IProductRepo context)
        {
            this.context = context;
        }
        public IActionResult Index(string SearchText = "", int pg = 1)
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

            // Paging
            const int pageSize = 4;

            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = products.Count();
            int recSkip = (pg - 1) * pageSize;
            List<Product> retProducts = products.Skip(recSkip).Take(pageSize).ToList();
            SPager SearchPager = new SPager(recsCount, pg, pageSize)
            {
               Controller = "Product",
               Action = "Index",
               SearchText = SearchText
            };

            ViewBag.SearchPager = SearchPager;

            return View(retProducts);
        }
    }
}
