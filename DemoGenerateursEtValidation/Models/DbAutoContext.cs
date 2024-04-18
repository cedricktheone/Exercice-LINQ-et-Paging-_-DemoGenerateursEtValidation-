using Microsoft.EntityFrameworkCore;

namespace DemoGenerateursEtValidation.Models
{
    public class DbAutoContext : DbContext
    {
        public DbAutoContext(DbContextOptions<DbAutoContext> options) : base(options)
        {
        }

        public DbSet<Auto> Autos {get; set;}
    }
}
