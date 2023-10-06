using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Name}")]
public sealed class ParcelSize : AggregateRoot<ParcelSize>
{
    public string Name { get; set; } = default!;
    public double MaxHeight { get; set; }
    public double MaxDepth { get; set; }
    public double MaxBreadth { get; set; }
}
