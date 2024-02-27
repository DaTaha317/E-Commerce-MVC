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

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public void Delete(int id)
        {
            context.Customers.Remove(GetById(id));
        }

        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return context.Customers.SingleOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, Customer customer)
        {
            if (GetById(id) != null)
            {
                context.Update(customer);
            }

        }
    }
}
