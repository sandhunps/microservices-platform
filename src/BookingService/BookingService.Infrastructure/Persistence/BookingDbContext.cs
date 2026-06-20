using Microsoft.EntityFrameworkCore;
using BookingService.Domain;

namespace BookingService.Infrastructure.Persistence;

public sealed class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
    {
    }

    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookingDbContext).Assembly);
    }
}
