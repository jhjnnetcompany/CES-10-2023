using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Infrastructure.Database.Locations;

public sealed class ParcelCategoryConfiguration : IEntityTypeConfiguration<ParcelCategory>
{
    public void Configure(EntityTypeBuilder<ParcelCategory> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
