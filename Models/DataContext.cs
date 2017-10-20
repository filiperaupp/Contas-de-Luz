using Microsoft.EntityFrameworkCore;

namespace energy_bill.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {}

        public DbSet<BillEnergy> Bills { get; set;}
    }
}