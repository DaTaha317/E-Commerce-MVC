using Castle.Core.Resource;
using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewComponents;
using E_Commerce_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.countries = Data.Data.GetCountryList();
            var CustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<CartItem> cartItems = cartItemRepo.GetCartItemsOfCustomer(CustomerId);
            ViewBag.Cart = cartItems;
            return View("Index");
        }

        [Authorize]
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

            }

            return View("Index");
        }

        [Authorize(Roles ="admin")]
        public IActionResult AllData(string SearchText = "", int pg = 1)
        {
            List<Shipment> shipments;

            if (SearchText != "" && SearchText != null)
            {
                shipments = context.GetAll(SearchText);
            }
            else
            {
                shipments = context.GetAll();
            }

            // Paging
            const int pageSize = 4;

            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = shipments.Count();
            int recSkip = (pg - 1) * pageSize;
            List<Shipment> retProducts = shipments.Skip(recSkip).Take(pageSize).ToList();
            SPager SearchPager = new SPager(recsCount, pg, pageSize)
            {
                Controller = "Shipment",
                Action = "AllData",
                SearchText = SearchText
            };

            ViewBag.SearchPager = SearchPager;

            return View(retProducts);
        }

        [Authorize(Roles = "customer")]
        public IActionResult DataById(string SearchText = "", int pg = 1)
        {
            List<Shipment> shipments;
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (SearchText != "" && SearchText != null)
            {
                shipments = context.GetAllById(customerId, SearchText);
            }
            else
            {
                shipments = context.GetAllById(customerId);
            }

            // Paging
            const int pageSize = 4;

            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = shipments.Count();
            int recSkip = (pg - 1) * pageSize;
            List<Shipment> retProducts = shipments.Skip(recSkip).Take(pageSize).ToList();
            SPager SearchPager = new SPager(recsCount, pg, pageSize)
            {
                Controller = "Shipment",
                Action = "DataById",
                SearchText = SearchText
            };

            ViewBag.SearchPager = SearchPager;

            return View(retProducts);
        }

    }
}
