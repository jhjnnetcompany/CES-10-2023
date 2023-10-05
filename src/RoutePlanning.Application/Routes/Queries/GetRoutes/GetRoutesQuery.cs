using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Application.Routes.Queries.GetRoutes.Models;

namespace RoutePlanning.Application.Routes.Queries.GetRoutes;
public sealed record GetRoutesQuery(
    IEnumerable<string> CategoryNames,
    string DestinationName,
    string OriginName,
    int Height,
    int Depth,
    int Breadth,
    int Weight
    ) : IQuery<IEnumerable<RouteDetails>>;
