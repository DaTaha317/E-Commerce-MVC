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


        public void Save()
        {
            context.SaveChanges();
        }

        //public void Update(string id, User customer)
        //{
        //    if (GetById(id) != null)
        //    {
        //        context.Customers.Update(customer);
        //    }

        //}

    }
}
