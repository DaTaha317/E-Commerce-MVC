using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_MVC.Controllers
{
    [Authorize]
    public class CartItemController : Controller
    {
        private ICartItemRepo context;
        private IProductRepo productRepo;
        private UserManager<User> userManager;
        
        public CartItemController(ICartItemRepo context, IProductRepo productRepo, UserManager<User> userManager)
        {
            this.context = context;
            this.productRepo = productRepo;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            List<CartItem> cartItem = context.GetCartItemsOfCustomer(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(cartItem);
        }
        public IActionResult Remove(int productId, string customerId)
        {
            context.Delete(productId, customerId);
            context.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(context.GetById(productId, Id) != null)
            {
                context.GetById(productId, Id).Quantity++;
            }
            else
            {
                CartItem cartItem = new()
                {
                    ProductId = productId,
                    CustomerId = Id,
                    Quantity = 1,
                };

                context.Add(cartItem);
            }
            context.Save();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult DeleteCartItems()
        {
            List<CartItem> cartItems = context.GetCartItemsOfCustomer(User.FindFirstValue(ClaimTypes.NameIdentifier));

            foreach(CartItem cartItem in cartItems)
            {
                Product product = productRepo.GetById((int)cartItem.ProductId);
                product.Stock -= cartItem.Quantity;
                productRepo.Update(product.Id, product);
                productRepo.Save();
                context.DeleteByCartItem(cartItem);
                context.Save();
            }

            return RedirectToAction("Index", "Shipment");
        }
    }
}
