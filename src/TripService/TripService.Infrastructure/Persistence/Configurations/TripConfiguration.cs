using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripService.Domain;

namespace TripService.Infrastructure.Persistence.Configurations;

public sealed class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Origin)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Destination)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.DepartureDate)
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .IsRequired();
    }
}
