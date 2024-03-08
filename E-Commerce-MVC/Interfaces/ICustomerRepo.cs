using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface ICustomerRepo
    {
        public List<User> GetAll();
        public User GetById(string id);
        public void Add(User customer);
        public void Update(string id, User customer);
        public void Delete(string id);
        public void Save();
    }
}
