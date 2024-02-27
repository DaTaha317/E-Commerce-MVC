using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepo context;

        public CustomerController(ICustomerRepo context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Customer> customers = context.GetAll();
            return View(customers);
        }
    }
}
