using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private ECommerceDB context;

        public CategoryRepo(ECommerceDB context)
        {
            this.context = context;
        }
       public void Add(Category category)
        {
            context.Categories.Add(category);
        }

        public void Delete(int id)
        {
            context.Categories.Remove(GetById(id));
        }

        public List<Category>GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.SingleOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

       public void Update(int id, Category category)
        {
            if (GetById(id) != null)
            {
                context.Update(category);
            }
        }
    }
}
