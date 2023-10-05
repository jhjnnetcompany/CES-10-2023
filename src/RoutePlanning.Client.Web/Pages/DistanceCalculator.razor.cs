using MediatR;
using Microsoft.AspNetCore.Components;
using RoutePlanning.Application.Category.Queries.SelectableCategoryList;
using RoutePlanning.Application.Locations.Queries.Distance;
using RoutePlanning.Application.Locations.Queries.SelectableLocationList;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Client.Web.Pages;

public sealed partial class DistanceCalculator
{
    private IEnumerable<SelectableLocation>? Locations { get; set; }
    private IEnumerable<SelectableCategory>? Categories { get; set; }
    private double? WeightInKilos { get; set; }
    private SelectableLocation? SelectedSource { get; set; }
    private SelectableLocation? SelectedDestination { get; set; }
    private DateTime? SelectedDepartureDate { get; set; }
    private DateTime? SelectedArrivalDate { get; set; }

    private ParcelSize ParcelSize = new();
    private SelectableCategory? SelectedCategory { get; set; }
    private string? DisplaySource { get; set; }
    private string? DisplayDestination { get; set; }
    private double? DisplayDistance { get; set; }

    [Inject]
    private IMediator Mediator { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Locations = await Mediator.Send(new SelectableLocationListQuery(), CancellationToken.None);
        Categories = await Mediator.Send(new SelectableCategoryListQuery(), CancellationToken.None);
        ParcelSize = new();
    }

    private async Task CalculateDistance()
    {
        if (SelectedSource is not null && SelectedDestination is not null)
        {
            DisplaySource = SelectedSource.Name;
            DisplayDestination = SelectedDestination.Name;
            DisplayDistance = await Mediator.Send(new DistanceQuery(SelectedSource.LocationId, SelectedDestination.LocationId), CancellationToken.None);
        }
    }
}
