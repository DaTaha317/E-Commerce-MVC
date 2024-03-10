using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewComponents;
using E_Commerce_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace E_Commerce_MVC.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private IProductRepo context;
        private ICategoryRepo categoryRepo;

        public ProductController(IProductRepo context, ICategoryRepo categoryRepo)
        {
            this.context = context;
            this.categoryRepo = categoryRepo;
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        public IActionResult Detail(int Id)
        {
            Product product = context.GetById(Id);

            return View(product);
        }

        [HttpGet]
        public IActionResult add()
        {
            List<Category> categories = categoryRepo.GetAll();
            SelectList selectList = new SelectList(categories.Select(item => new { Id = item.Id, Name = item.Name }), "Id", "Name");
            ViewBag.selectList = selectList;
            return View();
        }

        [HttpPost]
        public IActionResult add(ProductVM productVM)
        {
            Product product = new Product()
            {
                Name = productVM.Name,
                Description = productVM.Description,
                Price = productVM.Price,
                Stock = productVM.Stock,
                Image = productVM.Image,
                CategoryId = productVM.CategoryId,
            };

            context.Add(product);
            context.Save();
            return RedirectToAction("Index");
        }
    }
}
