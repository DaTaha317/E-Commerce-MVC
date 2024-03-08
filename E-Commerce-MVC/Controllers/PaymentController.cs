using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddPayment()
        {
            Payment payment = new()
            {
                Date = DateTime.Now,
                Method = "Credit Card",
                Amount = cartItemRepo.GetTotalPrice(1),
                CustomerId = 1
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
