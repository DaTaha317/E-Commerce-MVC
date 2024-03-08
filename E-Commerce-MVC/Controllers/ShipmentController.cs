using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_MVC.Controllers
{
    public class ShipmentController : Controller
    {
        private IShipmentRepo context;
        private ICartItemRepo cartItemRepo;
        private IOrderItemRepo orderItemRepo;
        public ShipmentController(IShipmentRepo context, ICartItemRepo cartItemRepo)
        {
            this.context = context;
            this.cartItemRepo = cartItemRepo;
        }
        public IActionResult Index()
        {
            //List<Shipment> shipments = context.GetAll();

            ViewBag.countries = Data.Data.GetCountryList();
            List<CartItem> cartItems = cartItemRepo.GetAll();
            ViewBag.Cart = cartItems;
            return View("Index");
        }
        [HttpPost]
        public IActionResult postShippment(ShippmentVM shippmentVM)
        {

            if (ModelState.IsValid)
            {
                Shipment shipment = new()
                {
                    Date = DateTime.Now,
                    Address = shippmentVM.Address,
                    City = shippmentVM.City,
                    State = shippmentVM.State,
                    Country = shippmentVM.Country,
                    ZipCode = shippmentVM.ZipCode,
                    CustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Status = ShipmentStatus.Pending
                };
                context.Add(shipment);
                context.Save();

                TempData["ShipmentId"] = shipment.Id;
                return RedirectToAction("AddPayment", "Payment");

                //List<CartItem> cartItems = cartItemRepo.GetAll();
                //if(cartItems.Count > 0)
                //{
                //    foreach(CartItem cartItem in cartItems)
                //    {

                //        cartItemRepo.DeleteByCartItem(cartItem);
                //        cartItemRepo.Save();

                //    }
                //}
            }

            return View("Index");
        }

    }
}
