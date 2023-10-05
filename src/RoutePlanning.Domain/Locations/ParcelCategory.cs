using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

public sealed class ParcelCategory : Entity<ParcelCategory>
{
    public string Name { get; set; } = default!;
    public double PriceFactor { get; set; } = 1;
    public bool IsSupported { get; set; }
}
