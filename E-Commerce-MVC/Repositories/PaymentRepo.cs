using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Repositories
{
    public class PaymentRepo : IPaymentRepo
    {
        private ECommerceDB context;
        public PaymentRepo(ECommerceDB context)
        {
            this.context = context;
        }
        public void Add(Payment payment)
        {
            context.Payments.Add(payment);
        }

        public void Delete(int id)
        {
            context.Payments.Remove(GetById(id));
        }

        public List<Payment> GetAll(string SearchText = "")
        {
            if (SearchText != "" && SearchText != null)
            {
                return context.Payments.Where(p => p.customer.FirstName.Contains(SearchText) || p.customer.LastName.Contains(SearchText)).ToList();
            }
            else
            {
                return context.Payments.ToList();
            }
        }

        public Payment GetById(int id)
        {
            return context.Payments.SingleOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, Payment payment)
        {
            if(GetById(id) != null)
            {
                context.Payments.Update(payment);
            }
        }
    }
}
