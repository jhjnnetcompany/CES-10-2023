using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Bookings;
public sealed class Category : Entity<Category>
{
    public string Name { get; set; } = default!;
}
