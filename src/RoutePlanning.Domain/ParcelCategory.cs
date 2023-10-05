using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Bookings;

namespace RoutePlanning.Domain;

public sealed class ParcelCategory : Entity<ParcelCategory>
{
    public IEnumerable<Booking> Booking { get; set; } = default!;
    public string Name { get; set; } = default!;
    public double PriceFactor { get; set; } = 1;
    public bool IsSupported { get; set; }
}
