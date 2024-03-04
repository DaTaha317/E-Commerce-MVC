using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private ECommerceDB context;

        public ProductRepo(ECommerceDB context)
        {
            this.context = context;
        }
        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public void Delete(int id)
        {
            context.Products.Remove(GetById(id));
        }

        public List<Product> GetAll(string SearchText = "")
        {
            if (SearchText != "" &&  SearchText != null)
            {
                return context.Products.Where(p => p.Name.Contains(SearchText)).ToList();
            }
            else
            {
				return context.Products.ToList();
			}    
        }

        public Product GetById(int id)
        {
            return context.Products.SingleOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, Product prod)
        {
            if (GetById(id) != null)
            {
                context.Update(prod);
            }

        }
    }
}
