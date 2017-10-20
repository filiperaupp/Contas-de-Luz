using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace energy_bill.Models
{
    public class BillEnergyRepository : IBillEnergyRepository
    {
         private DataContext context;
        public BillEnergyRepository(DataContext context)
        {           
            this.context = context;
        }


        public void Save(BillEnergy bill)
        {
            context.Bills.Add(bill);
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            context.Bills.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(BillEnergy bill)
        {
            context.Entry(bill).State = EntityState.Modified;
            context.SaveChanges();
        }

        public BillEnergy GetById(int id)
        {
            return context.Bills.SingleOrDefault(x=>x.id == id);
        }

        public List<BillEnergy> GetAll()
        {
            return context.Bills.OrderBy(x => x.dateRead).ToList();
        }

        public BillEnergy GetTheBillMax(){
            List<BillEnergy> contas = GetAll();
            DateTime padrao = new DateTime(2000,01,01);
            if (contas.Count==0) {
                
                BillEnergy contaVazia = new BillEnergy(0,padrao,0,0,0.0,padrao,0);
                return contaVazia;
            }
            else {
                var theMaxBill = contas.Max(x=>x.kwSpent);
                return contas.Where(x=>x.kwSpent==theMaxBill).FirstOrDefault();
            }
            

        }

        public BillEnergy GetTheBillMin(){
            List<BillEnergy> contas = GetAll();
            DateTime zeroZero = new DateTime(2000,01,01);
            if (contas.Count==0) {
                BillEnergy contaVazia = new BillEnergy(0,zeroZero,0,0,0.0,zeroZero,0);
                return contaVazia;
            }
            else {
                var theMaxBill = contas.Min(x=>x.kwSpent);
                return contas.Where(x=>x.kwSpent==theMaxBill).FirstOrDefault();
            }
        }
    }
}