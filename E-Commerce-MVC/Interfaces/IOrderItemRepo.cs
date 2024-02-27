using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface IOrderItemRepo
    {
        public List<OrderItem> GetAll();
        public OrderItem GetById(int productId, int orderId);
        public void Add(OrderItem item);
        public void Update(int productId, int orderId, OrderItem item);
        public void Delete(int productId, int orderId);
        public void Save();
    }
}
