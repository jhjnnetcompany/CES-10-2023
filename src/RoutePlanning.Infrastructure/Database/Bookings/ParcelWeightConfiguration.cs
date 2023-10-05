using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain;

namespace RoutePlanning.Infrastructure.Database.Bookings;

public sealed class ParcelWeightConfiguration : IEntityTypeConfiguration<ParcelWeight>
{
    public void Configure(EntityTypeBuilder<ParcelWeight> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(256);
    }
}

