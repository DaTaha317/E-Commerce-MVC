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
            return context.CartItems.SingleOrDefault(i=>i.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, CartItem item)
        {
            if (GetById(id) != null)
            {
               context.Update(item);
            }
            
        }
    }
}
