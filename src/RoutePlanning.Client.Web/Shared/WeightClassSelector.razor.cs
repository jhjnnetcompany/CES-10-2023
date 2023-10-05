using Microsoft.AspNetCore.Components;
using RoutePlanning.Application.WeightClass.Queries;

namespace RoutePlanning.Client.Web.Shared;

public sealed partial class WeightClassSelector
{

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public IEnumerable<SelectableWeightClass>? WeightClasses { get; set; }

    [Parameter]
    public SelectableWeightClass? Selected { get; set; }

    [Parameter]
    public EventCallback<SelectableWeightClass?> SelectedChanged { get; set; }

    private async Task OnSelectedChanged(ChangeEventArgs e)
    {
        var selectedId = Guid.Parse((string?)e.Value ?? "");
        Selected = WeightClasses?.Single(l => l.WeightClassId == selectedId);
        await SelectedChanged.InvokeAsync(Selected);
    }
}
