﻿using E_Commerce_MVC.Interfaces;
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
        public IActionResult Remove(int productId)
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            context.Delete(productId, customerId);
            context.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (context.GetById(productId, Id) != null)
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

            foreach (CartItem cartItem in cartItems)
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

        public IActionResult IncrementProduct(int productId)
        {

            // get id of the user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // get product wanted by user 
            CartItem cartItem = context.GetById(productId, userId);

            if (cartItem == null)
            {
                return NoContent();
            }


            // increment
            cartItem.Quantity += 1;

            // update
            context.Update(productId, userId, cartItem);

            context.Save();


            return NoContent();

        }

        public IActionResult decreaseProduct(int productId)
        {
            // get id of the user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // get product wanted by user 
            CartItem cartItem = context.GetById(productId, userId);

            if (cartItem == null || cartItem.Quantity <= 1)
            {
                return NoContent();
            }

            // decrement
            cartItem.Quantity -= 1;

            // update
            context.Update(productId, userId, cartItem);

            context.Save();

            return NoContent();
        }

        // refresh the page
        public IActionResult UpdateCart()
        {
            context.Save();

            return RedirectToAction(nameof(Index));
        }

        

    }
}
