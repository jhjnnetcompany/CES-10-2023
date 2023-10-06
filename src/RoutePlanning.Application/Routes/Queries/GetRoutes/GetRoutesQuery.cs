using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Application.Routes.Queries.GetRoutes.Models;

namespace RoutePlanning.Application.Routes.Queries.GetRoutes;
public sealed record GetRoutesQuery(
    IEnumerable<string> CategoryNames,
    double Height,
    double Depth,
    double Breadth,
    double Weight
    ) : IQuery<IEnumerable<RouteDetails>>;
