using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;
using Netcompany.Net.DomainDrivenDesign.Services;
using RoutePlanning.Domain;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Routes.Queries.GetParcelCategories;

public sealed class GetParcelCategoriesQueryHandler : IQueryHandler<GetParcelCategoriesQuery, double>
{
    private readonly IRepository<ParcelSize> _sizes;
    private readonly IQueryable<ParcelCategory> _parcelCategories;
    private readonly IQueryable<ParcelPrice> _parcelPrizes;

    public GetParcelCategoriesQueryHandler(IRepository<ParcelSize> sizes, IQueryable<ParcelPrice> parcelPrices,
    IQueryable<ParcelCategory> parcelCategories)
    {
        _parcelPrizes = parcelPrices;
        _sizes = sizes;
        _parcelCategories = parcelCategories;
    }

    public async Task<double> Handle(GetParcelCategoriesQuery command, CancellationToken cancellationToken)
    {

        var priceFactor = await CalculatePriceFactor(command.CategoryNames);

        var size = await GetSizeCategory(command.Size.MaxHeight, command.Size.MaxDepth, command.Size.MaxBreadth);

        var price = await _parcelPrizes
            .Where(x => x.ParcelSize == size && x.ParcelWeight.MaxWeight > command.WeightInKilos)
            .OrderBy(x => x.ParcelWeight.MaxWeight)
            .FirstAsync(cancellationToken);

        return price.priceInDollars * priceFactor;

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

    public async Task<ParcelSize> GetSizeCategory(double height, double depth, double breadth)
    {
        var query = await _sizes
                       .Where(s => s.MaxHeight > height && s.MaxDepth > depth && s.MaxBreadth > breadth)
                       .OrderBy(x => x.Name)
                       .ToListAsync();

        return query[0];
    }
}
