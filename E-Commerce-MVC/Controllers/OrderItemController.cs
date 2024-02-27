using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class OrderItemController : Controller
    {
        private IOrderItemRepo context;
        public OrderItemController(IOrderItemRepo context)
        {
            this.context = context;   
        }
        public IActionResult Index()
        {
            List<OrderItem> orderItems = context.GetAll();
            return View(orderItems);
        }
    }
}
