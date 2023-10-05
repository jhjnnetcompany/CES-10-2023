using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Value} km")]
public sealed record Distance : IValueObject
{
    public Distance(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "A distance must be greater than zero");
        }

        Value = value;
    }

    public double Value { get; private set; }

    public static implicit operator Distance(double distance) => new(distance);

    public static implicit operator double(Distance distance) => distance.Value;
}
