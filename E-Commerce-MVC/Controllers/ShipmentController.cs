using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
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
            return View(shipments);
        }
    }
}
