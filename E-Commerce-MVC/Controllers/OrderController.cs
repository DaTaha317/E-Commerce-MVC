using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public IActionResult AddOrder()
        {
            Order order = new Order()
            {
                Date = DateTime.Now,
                Price = decimal.Parse(TempData["Amount"] as string),
                CustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                PaymentId = (int?)TempData["PaymentId"],
                ShipmentId = (int?)TempData["ShipmentId"]
            };

            context.Add(order);
            context.Save();

            TempData["OrderId"] = order.Id;

            return RedirectToAction("AddOrderItem", "OrderItem");
        }
    }
}
