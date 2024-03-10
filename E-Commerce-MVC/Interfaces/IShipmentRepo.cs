using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Interfaces
{
    public interface IShipmentRepo
    {
        public List<Shipment> GetAll(string SearchText = "");
        public List<Shipment> GetAllById(string customerId, string SearchText = "");
        public Shipment GetById(int id);
        public void Add(Shipment shipment);
        public void Update(int id, Shipment shipment);
        public void Delete(int id);
        public void Save();
    }
}
