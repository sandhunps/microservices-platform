using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookingService.Infrastructure.Persistence;

public sealed class BookingDbContextFactory : IDesignTimeDbContextFactory<BookingDbContext>
{
    public BookingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookingDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5434;Database=bookingsdb;Username=admin;Password=secret");

        return new BookingDbContext(optionsBuilder.Options);
    }
}
