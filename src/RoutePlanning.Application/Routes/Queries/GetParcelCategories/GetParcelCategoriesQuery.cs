using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Routes.Queries.GetParcelCategories;
public sealed record GetParcelCategoriesQuery(
    IEnumerable<string> CategoryNames,
    ParcelSize Size,
    double WeightInKilos
    ) : IQuery<double>;
