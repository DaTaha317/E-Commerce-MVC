using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.ViewComponents;
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
        public IActionResult Index(string SearchText = "", int pg = 1)
        {
            List<Payment> payments;

            if (SearchText != "" && SearchText != null)
            {
                payments = context.GetAll(SearchText);
            }
            else
            {
                payments = context.GetAll();
            }

            // Paging
            const int pageSize = 4;

            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = payments.Count();
            int recSkip = (pg - 1) * pageSize;
            List<Payment> retProducts = payments.Skip(recSkip).Take(pageSize).ToList();
            SPager SearchPager = new SPager(recsCount, pg, pageSize)
            {
                Controller = "Payment",
                Action = "Index",
                SearchText = SearchText
            };

            ViewBag.SearchPager = SearchPager;

            return View(retProducts);
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
