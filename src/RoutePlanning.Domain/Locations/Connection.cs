using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Source} --{TimeInHours}--> {Destination}")]
public sealed class Connection : Entity<Connection>
{
    public Connection(Location source, Location destination, Distance timeInHours, Distance costInDollars, Company company)
    {
        Source = source;
        Destination = destination;
        TimeInHours = timeInHours;
        CostInDollars = costInDollars;
        Company = company;
    }

    private Connection()
    {
        Source = null!;
        Destination = null!;
        TimeInHours = null!;
        CostInDollars = null!;
        Company = null!;
    }

    public Location Source { get; private set; }

    public Location Destination { get; private set; }

    public Distance TimeInHours { get; private set; }

    public Distance CostInDollars { get; private set; }

    public Company Company { get; private set; }
}
