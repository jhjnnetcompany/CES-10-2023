using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain;

namespace RoutePlanning.Infrastructure.Database.Bookings;

public sealed class ParcelCategoryConfiguration : IEntityTypeConfiguration<ParcelCategory>
{
    public void Configure(EntityTypeBuilder<ParcelCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Booking)
            .WithMany(x => x.Categories);

    }
}
