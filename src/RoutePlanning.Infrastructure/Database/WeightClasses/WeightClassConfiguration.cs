using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.WeightClasses;

namespace RoutePlanning.Infrastructure.Database.Categories;

public sealed class WeightClassConfiguration : IEntityTypeConfiguration<Domain.WeightClasses.WeightClass>
{
    public void Configure(EntityTypeBuilder<WeightClass> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(256);
    }
}

