using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface ICartItemRepo
    {
        public List<CartItem> GetAll();
        public CartItem GetById(int productId, string customerId);
        public void Add(CartItem item);
        public void Update(int productId, string customerId, CartItem item);
        public void Delete(int productId, string customerId);
        public void Save();
    }
}
