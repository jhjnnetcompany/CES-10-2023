using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Bookings;

namespace RoutePlanning.Infrastructure.Database.Bookings;

public sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Origin).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Destination).WithMany().OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.Categories)
            .WithMany(x => x.Booking);
    }
}
