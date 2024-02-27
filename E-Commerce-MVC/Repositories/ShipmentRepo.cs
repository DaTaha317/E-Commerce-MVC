using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;

namespace E_Commerce_MVC.Repositories
{
    public class ShipmentRepo : IShipmentRepo
    {
        private ECommerceDB context;

        public ShipmentRepo(ECommerceDB context)
        {
            this.context = context;
        }
        public void Add(Shipment shipment)
        {
            context.Shipments.Add(shipment);
        }

        public void Delete(int id)
        {
            context.Shipments.Remove(GetById(id));
        }

        public List<Shipment> GetAll()
        {
            return context.Shipments.ToList();  
        }

        public Shipment GetById(int id)
        {
            return context.Shipments.SingleOrDefault(sh => sh.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, Shipment shipment)
        {
            if(GetById(id) != null)
            {
                context.Shipments.Update(shipment);
            }
        }
    }
}
