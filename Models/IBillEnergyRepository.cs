using System.Collections.Generic;

namespace energy_bill.Models
{
    public interface IBillEnergyRepository
    {
         BillEnergy GetById(int id);
         List<BillEnergy> GetAll();
         void Save (BillEnergy bill);
         void Delete(int id);
         void Update(BillEnergy bill);
         BillEnergy GetTheBillMax();
         BillEnergy GetTheBillMin();
    }
}