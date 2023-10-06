using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;
using Netcompany.Net.DomainDrivenDesign.Services;
using RoutePlanning.Application.Routes.Queries.GetRoutes.Models;
using RoutePlanning.Domain;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Routes.Queries.GetRoutes;

public sealed class GetBookingQueryHandler : IQueryHandler<GetRoutesQuery, IEnumerable<RouteDetails>>
{
    private readonly IRepository<Connection> _connections;
    private readonly IRepository<ParcelSize> _sizes;
    private readonly IQueryable<ParcelCategory> _parcelCategories;

    public GetBookingQueryHandler(IRepository<Connection> connections, IRepository<ParcelSize> sizes, IQueryable<ParcelCategory> parcelCategories)
    {
        _sizes = sizes;
        _connections = connections;
        _parcelCategories = parcelCategories;
    }

    public async Task<IEnumerable<RouteDetails>> Handle(GetRoutesQuery command, CancellationToken cancellationToken)
    {
        var isCategoryUnsupported = await _parcelCategories
            .Where(x => !x.IsSupported)
            .AnyAsync(x => command.CategoryNames
                .Select(c => c.ToLower())
                .Contains(x.Name.ToLower()), cancellationToken);

        if (isCategoryUnsupported ||
            command.Weight > 20 ||
            command.Height > 200 ||
            command.Weight > 200 ||
            command.Breadth > 200
           )
        {
            return new List<RouteDetails>();
        }

        var priceFactor = await CalculatePriceFactor(
            command.CategoryNames);

        return await _connections.Select(x => new RouteDetails
        {
            OriginName = x.Source.Name,
            DestinationName = x.Destination.Name,
            CostInDollars = x.CostInDollars.Value * priceFactor,
            TimeInHours = x.TimeInHours.Value

        }).ToListAsync(cancellationToken);
    }
    public async Task<double> CalculatePriceFactor(IEnumerable<string> categories)
    {

        var selectedCategories = await _parcelCategories.Where(x => categories.Contains(x.Name)).ToListAsync();

        var priceFactor = 1.0;
        foreach (var category in selectedCategories)
        {
            priceFactor *= (1 + category.PriceFactor);
        }

        return priceFactor;
    }
}
