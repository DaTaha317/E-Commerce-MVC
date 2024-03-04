using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Controllers
{
    public class CartItemController : Controller
    {
        private ICartItemRepo context;
        public CartItemController(ICartItemRepo context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<CartItem> cartItem = context.GetAll();
            return View(cartItem);
        }
        public IActionResult Remove(int pId, int cId)
        {
            context.Delete(pId, cId);
            context.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
