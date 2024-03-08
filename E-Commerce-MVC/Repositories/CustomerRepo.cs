using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private ECommerceDB context;

        public CustomerRepo(ECommerceDB context)
        {
            this.context = context;
        }

        public void Add(User customer)
        {
            context.Customers.Add(customer);
        }

        public void Delete(string id)
        {
            context.Customers.Remove(GetById(id));
        }

        public List<User> GetAll()
        {
            return context.Customers.ToList();
        }

        public User GetById(string id)
        {
            return context.Customers.SingleOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string id, User customer)
        {
            if (GetById(id) != null)
            {
                context.Update(customer);
            }

        }
    }
}
