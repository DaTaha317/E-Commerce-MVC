using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface IPaymentRepo
    {
        public List<Payment> GetAll(string SearchText = "");
        public Payment GetById(int id);
        public void Add(Payment payment);
        public void Update(int id, Payment payment);
        public void Delete(int id);
        public void Save();
    }
}
