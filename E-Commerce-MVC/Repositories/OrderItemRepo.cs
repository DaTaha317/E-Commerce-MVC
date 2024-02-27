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

        public void Delete(int id)
        {
            context.OrderItems.Remove(GetById(id));
        }

        public List<OrderItem> GetAll()
        {
            return context.OrderItems.ToList();
        }

        public OrderItem GetById(int id)
        {
            return context.OrderItems.SingleOrDefault(i => i.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, OrderItem item)
        {
            if (GetById(id) != null)
            {
                context.Update(item);
            }
        }
    }
}
