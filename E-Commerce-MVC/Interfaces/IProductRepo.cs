using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface IProductRepo
    {
        public List<Product> GetAll(string SearchText = "");
        public Product GetById(int id);
        public void Add(Product product);
        public void Update(int id,Product product);
        public void Delete(int id);
        public void Save();
    }
}
