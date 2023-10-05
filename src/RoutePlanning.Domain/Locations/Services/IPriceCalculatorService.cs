using Netcompany.Net.DomainDrivenDesign.Services;

namespace RoutePlanning.Domain.Locations.Services;

public interface IPriceCalculatorService : IDomainService
{
    IEnumerable<Connection> CalculateShortestDistance(Location source, Location target);
}
