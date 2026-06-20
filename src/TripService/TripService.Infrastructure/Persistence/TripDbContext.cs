using Microsoft.EntityFrameworkCore;
using TripService.Domain;

namespace TripService.Infrastructure.Persistence;

public sealed class TripDbContext : DbContext
{
    public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
    {
    }

    public DbSet<Trip> Trips => Set<Trip>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TripDbContext).Assembly);
    }
}