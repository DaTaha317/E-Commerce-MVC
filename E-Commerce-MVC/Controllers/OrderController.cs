using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepo context;
        public OrderController(IOrderRepo context)
        {
            this.context=context;
        }
        public IActionResult Index()
        {
            List<Order> orders = context.GetAll();
            return View(orders);
        }
    }
}
