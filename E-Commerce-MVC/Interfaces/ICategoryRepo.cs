using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface ICategoryRepo
    {
        public List<Category> GetAll();
        public Category GetById(int id);
        public void Add(Category category);
        public void Update(int id, Category category);
        public void Delete(int id);
        public void Save();
    }
}
