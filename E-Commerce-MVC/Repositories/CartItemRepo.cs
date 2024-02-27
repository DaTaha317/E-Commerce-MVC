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
        public void Add(CartItem cartItem)
        {
            context.CartItems.Add(cartItem);
        }

        public void Delete(int id)
        {
            context.CartItems.Remove(GetById(id));
        }

        public List<CartItem> GetAll()
        {
            return context.CartItems.ToList();
        }

        public CartItem GetById(int id)
        {
            return context.CartItems.SingleOrDefault(i=>id==id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, CartItem category)
        {
            if (GetById(id) != null)
            {
               context.Update(category);
            }
            
        }
    }
}
