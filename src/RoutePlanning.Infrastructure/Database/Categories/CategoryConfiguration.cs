using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Categories;

namespace RoutePlanning.Infrastructure.Database.Categories;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Domain.Categories.Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(256);
    }
}
