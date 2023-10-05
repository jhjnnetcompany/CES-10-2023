using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Infrastructure.Database.Locations;

public sealed class ConnectionConfiguration : IEntityTypeConfiguration<Connection>
{
    public void Configure(EntityTypeBuilder<Connection> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Destination).WithMany();

        //builder.HasOne(x => x.Company);

        builder.OwnsOne(x => x.TimeInHours);

        builder.OwnsOne(x => x.CostInDollars);
    }
}
