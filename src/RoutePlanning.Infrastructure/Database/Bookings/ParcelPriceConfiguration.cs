using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Infrastructure.Database.Bookings;

public sealed class ParcelPriceConfiguration : IEntityTypeConfiguration<ParcelPrice>
{
    public void Configure(EntityTypeBuilder<ParcelPrice> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ParcelSize);

        builder.HasOne(x => x.ParcelWeight);
    }
}
