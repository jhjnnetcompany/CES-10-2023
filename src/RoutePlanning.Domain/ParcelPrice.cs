using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

public sealed class ParcelPrice : AggregateRoot<ParcelPrice>
{
    public ParcelSize? ParcelSize { get; set; }

    public ParcelWeight? ParcelWeight { get; set; }

    public double priceInDollars { get; set; }
}
