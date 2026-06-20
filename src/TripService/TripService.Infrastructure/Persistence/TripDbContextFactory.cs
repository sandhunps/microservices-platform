using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TripService.Infrastructure.Persistence;

public sealed class TripDbContextFactory : IDesignTimeDbContextFactory<TripDbContext>
{
    public TripDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TripDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5433;Database=tripsdb;Username=admin;Password=secret");

        return new TripDbContext(optionsBuilder.Options);
    }
}
