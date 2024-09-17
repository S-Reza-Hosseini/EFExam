using Microsoft.EntityFrameworkCore;
using Zoo.Entities;
using Zoo.Persistence.Zoos;

namespace Zoo.Persistence;

public class EFDataContext:DbContext
{
    public DbSet<Entities.Zoo> Zoos { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Animal> Animals { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Management Zoos;" +
                                    "Integrated Security=true;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZooEntityMap).Assembly);
    }
}