namespace RoutePlanning.Application.Routes.Queries.GetRoutes.Models;
public class RouteDetails
{
    public string OriginName { get; set; } = default!;
    public string DestinationName { get; set; } = default!;
    public double CostInDollars { get; set; } = default!;
    public double TimeInHours { get; set; } = default!;
}
