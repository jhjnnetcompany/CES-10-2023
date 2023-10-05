using MediatR;
using Microsoft.AspNetCore.Components;
using RoutePlanning.Application.Bookings.Commands.CreateBooking;
using RoutePlanning.Application.Category.Queries.SelectableCategoryList;
using RoutePlanning.Application.Locations.Queries.SelectableLocationList;
using RoutePlanning.Application.Routes.Queries.GetRoutes.Models;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Client.Web.Pages;

public sealed partial class DistanceCalculator
{
    private IEnumerable<SelectableLocation> Locations { get; set; } = default!;
    private IEnumerable<SelectableCategory> Categories { get; set; } = default!;
    private double WeightInKilos { get; set; } = 0;
    private SelectableLocation? SelectedSource { get; set; }
    private SelectableLocation? SelectedDestination { get; set; }

    private ParcelSize ParcelSize = new();
    private SelectableCategory? SelectedCategory { get; set; }

    [Inject]
    private IMediator Mediator { get; set; } = default!;

    private IEnumerable<RouteDetails> Route = new List<RouteDetails>();

    protected override async Task OnInitializedAsync()
    {
        Locations = await Mediator.Send(new SelectableLocationListQuery(), CancellationToken.None);
        Categories = await Mediator.Send(new SelectableCategoryListQuery(), CancellationToken.None);
        ParcelSize = new();
    }

    private void CalculateDistance()
    {
        if (SelectedSource is not null && SelectedDestination is not null)
        {
            Route = new List<RouteDetails>
            {
                new()
                {
                    CostInDollars = 10,
                    DestinationName = SelectedDestination.Name,
                    OriginName = SelectedSource.Name,
                    TimeInHours = 8
                },
            };
        }
    }

    public async Task CreateBooking(RouteDetails routeDetails)
    {
        var command = new CreateBookingCommand(
            routeDetails.OriginName,
            routeDetails.DestinationName,
            DateTimeOffset.Now,
            WeightInKilos,
            ParcelSize.MaxHeight,
            ParcelSize.MaxDepth,
            ParcelSize.MaxBreadth,
            Categories.Select(x => x.Name).ToList());
        
        await Mediator.Send(command);
    }
}
