using Microsoft.EntityFrameworkCore;

namespace StarWarsApi.models
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options)
              : base(options)
        {
        }
        public DbSet<Civilian> Civilians { get; set; } = null!;
        public DbSet<ForceUsers> ForceUsers { get; set; } = null!;
        public DbSet<Gunslinger> Gunslingers { get; set; } = null!;
    }
}