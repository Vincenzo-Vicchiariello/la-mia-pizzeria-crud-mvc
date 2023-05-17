using Microsoft.EntityFrameworkCore;
using LaMiaPizzeriaNuova.Models;
namespace LaMiaPizzeriaNuova.DataBase
{
    public class PizzaContext : DbContext
    {
        public dbSet<PizzaModel> Pizze {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PizzaDb;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
