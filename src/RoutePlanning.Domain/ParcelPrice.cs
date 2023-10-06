using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

public sealed class ParcelPrice : AggregateRoot<ParcelPrice>
{
    public ParcelSize ParcelSize { get; set; } = default!;

    public ParcelWeight ParcelWeight { get; set; } = default!;

    public double priceInDollars { get; set; }
}
