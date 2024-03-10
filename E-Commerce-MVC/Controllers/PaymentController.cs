using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_MVC.Controllers
{
    public class PaymentController : Controller
    {
        private IPaymentRepo context;
        private ICartItemRepo cartItemRepo;

        public PaymentController(IPaymentRepo context, ICartItemRepo cartItemRepo)
        {
            this.context = context;
            this.cartItemRepo = cartItemRepo;
        }

        [Authorize(Roles ="admin")]
        public IActionResult Index()
        {
            List<Payment> payments = context.GetAll();
            return View(payments);
        }

        [Authorize(Roles ="customer")]
        public IActionResult AddPayment()
        {
            var Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Payment payment = new()
            {
                Date = DateTime.Now,
                Method = "Credit Card",
                Amount = cartItemRepo.GetTotalPrice(Id),
                CustomerId = Id
            };
            context.Add(payment);
            context.Save();

            int? ShipmentId = (int?)TempData["ShipmentId"];

			TempData["PaymentId"] = payment.Id;
            TempData["ShipmentId"] = ShipmentId;
            string amount = payment.Amount.ToString();
            TempData["Amount"] = amount;
            
            return RedirectToAction("AddOrder", "Order");
        }
    }
}
