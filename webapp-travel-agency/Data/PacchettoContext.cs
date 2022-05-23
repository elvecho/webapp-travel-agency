using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class PacchettoContext : DbContext
    {
        public DbSet<Pacchetto> pacchetti { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=localhost;Database=webapp_travel_agency;Integrated Security=True");

        }
        
    }
}
