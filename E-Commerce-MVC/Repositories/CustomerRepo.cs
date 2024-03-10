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

        public List<User> GetAll(string SearchText = "")
        {
            if (SearchText != "" && SearchText != null)
            {
                return context.Users.Where(p => p.FirstName.Contains(SearchText) || p.LastName.Contains(SearchText)).ToList();
            }
            else
            {
                return context.Users.ToList();
            }
        }

        public User GetById(string id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }


        public void Save()
        {
            context.SaveChanges();
        }
    }
}
