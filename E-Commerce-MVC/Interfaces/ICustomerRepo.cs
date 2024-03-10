using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface ICustomerRepo
    {
        public List<User> GetAll(string SearchText = "");
        public User GetById(string id);
        public void Save();

    }
}
