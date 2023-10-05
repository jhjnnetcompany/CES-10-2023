using Netcompany.Net.DomainDrivenDesign.Services;

namespace RoutePlanning.Domain.Locations.Services;

public interface ISearchRoutesService : IDomainService
{
    IEnumerable<Connection> GetFastestPath(Location source, Location target);
}
