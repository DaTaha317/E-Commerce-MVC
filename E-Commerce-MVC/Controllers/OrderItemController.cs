using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_MVC.Controllers
{
    public class OrderItemController : Controller
    {
        private IOrderItemRepo context;
        private ICartItemRepo cartItemRepo;
        public OrderItemController(IOrderItemRepo context, ICartItemRepo cartItemRepo)
        {
            this.context = context;   
            this.cartItemRepo = cartItemRepo;
        }
        public IActionResult Index()
        {
            List<OrderItem> orderItems = context.GetAll();
            return View(orderItems);
        }

        public IActionResult AddOrderItem()
        {
            List<CartItem> cartItems = cartItemRepo.GetCartItemsOfCustomer(User.FindFirstValue(ClaimTypes.NameIdentifier));


            foreach(CartItem cartItem in cartItems)
            {
                OrderItem orderItem = new OrderItem()
                {
                    Quantity = cartItem.Quantity,
                    Price = cartItemRepo.GetTotalPriceOfOneItem(cartItem),
                    OrderId = (int?)TempData["OrderId"],
                    ProductId = cartItem.ProductId
                };

                context.Add(orderItem);
                context.Save();
            }

            return RedirectToAction("DeleteCartItems", "CartItem");
        }
    }
}
