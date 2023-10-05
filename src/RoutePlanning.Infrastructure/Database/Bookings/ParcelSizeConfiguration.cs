using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Infrastructure.Database.Locations;

public sealed class ParcelSizeConfiguration : IEntityTypeConfiguration<ParcelSize>
{
    public void Configure(EntityTypeBuilder<ParcelSize> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
