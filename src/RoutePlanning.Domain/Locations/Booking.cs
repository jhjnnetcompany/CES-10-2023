using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

public sealed class Booking : AggregateRoot<Booking>
{
    public Location Origin { get; set; } = default!;
    public Location Destination { get; set; } = default!;
    public DateTimeOffset DepartureDate { get; set; } = default!;
    public DateTimeOffset ArrivalDate { get; set; } = default!;
    public string SizeCategory { get; set; } = default!;
    public int Weight { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string PackageStatus { get; set; } = default!;
}
