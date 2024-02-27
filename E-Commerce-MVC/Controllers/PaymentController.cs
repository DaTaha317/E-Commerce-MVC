using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class PaymentController : Controller
    {
        private IPaymentRepo context;

        public PaymentController(IPaymentRepo context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Payment> payments = context.GetAll();
            return View(payments);
        }
    }
}
