using Microsoft.EntityFrameworkCore;

namespace GaleriaGatos.Properties.Model
{
    public class GatosContext : DbContext
    {
        public GatosContext(DbContextOptions<GatosContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Gatos> Galeriagatos{ get; set; }
    }
}
