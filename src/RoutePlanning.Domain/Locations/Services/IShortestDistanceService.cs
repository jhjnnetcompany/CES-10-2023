using Netcompany.Net.DomainDrivenDesign.Services;

namespace RoutePlanning.Domain.Locations.Services;

public interface IShortestDistanceService : IDomainService
{
    IEnumerable<Connection> CalculateShortestDistance(Location source, Location target);
}
