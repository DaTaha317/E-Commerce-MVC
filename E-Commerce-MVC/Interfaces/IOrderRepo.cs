using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface IOrderRepo
    {
        public List<Order> GetAll();
        public Order GetById(int id);
        public void Add(Order order);
        public void Update(int id,Order order);
        public void Delete(int id);
        public void Save();
    }
}
