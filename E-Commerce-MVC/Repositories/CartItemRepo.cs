using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Repositories
{
    public class CartItemRepo : ICartItemRepo
    {
        private ECommerceDB context;
        public CartItemRepo(ECommerceDB context)
        {
            this.context = context;
        }
        public void Add(CartItem item)
        {
            context.CartItems.Add(item);
        }

        public void Delete(int productId, int customerId)
        {
            context.CartItems.Remove(GetById(productId, customerId));
        }

        public List<CartItem> GetAll()
        {
            return context.CartItems.ToList();
        }

        public CartItem GetById(int productId, int customerId)
        {
            return context.CartItems.SingleOrDefault(i=>i.ProductId == productId && i.CustomerId == customerId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int productId, int customerId, CartItem item)
        {
            if (GetById(productId, customerId) != null)
            {
               context.Update(item);
            }
            
        }
    }
}
