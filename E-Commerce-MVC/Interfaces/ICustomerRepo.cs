using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface ICustomerRepo
    {
        public List<Customer> GetAll();
        public Customer GetById(int id);
        public void Add(Customer customer);
        public void Update(int id, Customer customer);
        public void Delete(int id);
        public void Save();
    }
}
