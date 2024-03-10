using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    [Authorize(Roles ="admin")]
    public class CustomerController : Controller
    {
        private ICustomerRepo context;

        public CustomerController(ICustomerRepo context)
        {
            this.context = context;
        }

        public IActionResult Index(string SearchText = "", int pg = 1)
        {
            List<User> users;

            if (SearchText != "" && SearchText != null)
            {
                users = context.GetAll(SearchText);
            }
            else
            {
                users = context.GetAll();
            }

            // Paging
            const int pageSize = 4;

            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = users.Count();
            int recSkip = (pg - 1) * pageSize;
            List<User> retProducts = users.Skip(recSkip).Take(pageSize).ToList();
            SPager SearchPager = new SPager(recsCount, pg, pageSize)
            {
                Controller = "Customer",
                Action = "Index",
                SearchText = SearchText
            };

            ViewBag.SearchPager = SearchPager;

            return View(retProducts);
        }
    }
}
