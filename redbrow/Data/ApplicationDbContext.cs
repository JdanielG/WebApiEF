using Microsoft.EntityFrameworkCore;

namespace redbrow.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext( IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebDatabase"));
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}