using Microsoft.AspNetCore.Components;
using RoutePlanning.Application.Category.Queries.SelectableCategoryList;

namespace RoutePlanning.Client.Web.Shared;

public sealed partial class CategorySelector
{

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public IEnumerable<SelectableCategory>? Categories { get; set; }

    [Parameter]
    public SelectableCategory? Selected { get; set; }

    [Parameter]
    public EventCallback<SelectableCategory?> SelectedChanged { get; set; }

    private async Task OnSelectedChanged(ChangeEventArgs e)
    {
        var selectedId = Guid.Parse((string?)e.Value ?? "");
        Selected = Categories?.Single(l => l.LocationId == selectedId);
        await SelectedChanged.InvokeAsync(Selected);
    }
}
