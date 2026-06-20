using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookingService.Domain;

namespace BookingService.Infrastructure.Persistence.Configurations;

public sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.CustomerName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Seats)
            .IsRequired();

        builder.Property(b => b.CreatedAt)
            .IsRequired();
    }
}
