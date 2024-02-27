using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface IOrderItemRepo
    {
        public List<OrderItem> GetAll();
        public OrderItem GetById(int id);
        public void Add(OrderItem item);
        public void Update(int id,OrderItem item);
        public void Delete(int id);
        public void Save();
    }
}
