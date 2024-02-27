using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface ICartItemRepo
    {
        public List<CartItem> GetAll();
        public CartItem GetById(int id);
        public void Add(CartItem item);
        public void Update(int id, CartItem item);
        public void Delete(int id);
        public void Save();
    }
}
