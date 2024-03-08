using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Repositories
{
    public class OrderItemRepo : IOrderItemRepo
    {
        private ECommerceDB context;
        public OrderItemRepo(ECommerceDB context)
        {
            this.context = context;
        }
        public void Add(OrderItem item)
        {
            context.OrderItems.Add(item);
        }

        public void Delete(int productId, int orderId)
        {
            context.OrderItems.Remove(GetById(productId,orderId));
        }

        public List<OrderItem> GetAll()
        {
            return context.OrderItems.ToList();
        }

        public OrderItem GetById(int productId, int orderId)
        {
            return context.OrderItems.SingleOrDefault(i => i.ProductId == productId && i.OrderId == orderId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int productId, int orderId, OrderItem item)
        {
            if (GetById(productId, orderId) != null)
            {
                context.OrderItems.Update(item);
            }
        }
    }
}
