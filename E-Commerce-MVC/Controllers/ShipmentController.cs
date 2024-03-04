using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class ShipmentController : Controller
    {
        private IShipmentRepo context;

        public ShipmentController(IShipmentRepo context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Shipment> shipments = context.GetAll();

            ViewBag.countries = Data.Data.GetCountryList();


            return View("Index");
        }
        [HttpPost]
        public IActionResult postShippment(ShippmentVM shippmentVM)
        {
            if (ModelState.IsValid)
            {
                // do what you want 
            }

            return View("Index");
        }

    }
}
