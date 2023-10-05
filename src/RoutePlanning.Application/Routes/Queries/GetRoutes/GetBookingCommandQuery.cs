using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;
using Netcompany.Net.DomainDrivenDesign.Services;
using RoutePlanning.Application.Routes.Queries.GetRoutes.Models;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Routes.Queries.GetRoutes;

public sealed class GetBookingCommandQuery : IQueryHandler<GetRoutesQuery, IEnumerable<RouteDetails>>
{
    private readonly IRepository<Connection> _connections;

    public GetBookingCommandQuery(IRepository<Connection> connections)
    {
        _connections = connections;
    }

    public async Task<IEnumerable<RouteDetails>> Handle(GetRoutesQuery command, CancellationToken cancellationToken)
    {
        if (command.CategoryNames.Any(x =>
                x.ToLower() is "recorded delivery" or "live animals") || // TODO: Move to separate 'Banned categories' table
            command.Weight > 20 ||
            command.Height > 200 ||
            command.Weight > 200 ||
            command.Breadth > 200
           )
        {
            return new List<RouteDetails>();
        }

        var priceFactor = CalculatePriceFactor(
            command.Weight,
            command.Height,
            command.Depth,
            command.Breadth);

        return await _connections.Select(x => new RouteDetails
        {
            OriginName = x.Source.Name,
            DestinationName = x.Destination.Name,
            CostInDollars = x.CostInDollars.Value * priceFactor,
            TimeInHours = x.TimeInHours.Value
        }).ToListAsync(cancellationToken);
    }
#pragma warning disable CA1822 // Mark members as static
    public double CalculatePriceFactor(double weightInKilos, int height, int depth, int breadth)
#pragma warning restore CA1822 // Mark members as static
    {
        var sizeCategory = GetSizeCategory(height, depth, breadth);
        return weightInKilos + sizeCategory;
    }

    public static double GetSizeCategory(int height, int depth, int breadth)
    {
        return height + depth + breadth;
    }
}
