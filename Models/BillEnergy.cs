using System;

namespace energy_bill.Models
{
    public class BillEnergy
    {
        
        public BillEnergy(){}

        public BillEnergy(int id, DateTime dateRead, int numberRead, int kwSpent, double price, DateTime datePayment, double avgComsumption)
        {
            this.id = id;
            this.dateRead = dateRead;
            this.numberRead = numberRead;
            this.kwSpent = kwSpent;
            this.price = price;
            this.datePayment = datePayment;
            this.avgComsumption = avgComsumption;

        }
        public int id { get; set; }
        public DateTime dateRead { get; set; }
        public int numberRead { get; set; }
        public int kwSpent { get; set; }
        public double price { get; set; }
        public DateTime datePayment { get; set; }
        public double avgComsumption { get; set; }
    }
}