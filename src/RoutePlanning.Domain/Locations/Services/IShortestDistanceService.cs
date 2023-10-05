using Netcompany.Net.DomainDrivenDesign.Services;

namespace RoutePlanning.Domain.Locations.Services;

public interface IShortestDistanceService : IDomainService
{
    double CalculateShortestDistance(Location source, Location target);
}
