using Microsoft.EntityFrameworkCore;

namespace VitalNutri_2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PlanoAlimentar> Planos { get; set; }
    }
}
