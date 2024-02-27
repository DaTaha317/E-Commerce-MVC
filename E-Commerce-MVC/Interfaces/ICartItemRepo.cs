using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface ICartItemRepo
    {
        public List<CartItem> GetAll();
        public CartItem GetById(int productId, int customerId);
        public void Add(CartItem item);
        public void Update(int productId, int customerId, CartItem item);
        public void Delete(int productId, int customerId);
        public void Save();
    }
}
