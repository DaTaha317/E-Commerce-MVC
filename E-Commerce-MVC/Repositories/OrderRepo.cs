using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private ECommerceDB context;
        public OrderRepo(ECommerceDB context)
        {
            this.context = context;   
        }
        public void Add(Order order)
        {
            context.Orders.Add(order);
        }

        public void Delete(int id)
        {
            context.Orders.Remove(GetById(id));
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetById(int id)
        {
           return context.Orders.SingleOrDefault(o => o.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, Order order)
        {
            if (GetById(id) != null)
            {
                context.Orders.Update(order);
            }
        }
    }
}
