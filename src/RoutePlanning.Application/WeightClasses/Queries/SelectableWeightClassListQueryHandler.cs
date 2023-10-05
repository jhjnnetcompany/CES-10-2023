using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;

namespace RoutePlanning.Application.WeightClass.Queries;
public sealed class SelectableWeightClassListQueryHandler : IQueryHandler<SelectableWeightClassListQuery, IReadOnlyList<SelectableWeightClass>>
{
    private readonly IQueryable<Domain.ParcelWeight> _weightClasses;

    public SelectableWeightClassListQueryHandler(IQueryable<Domain.ParcelWeight> locations)
    {
        _weightClasses = locations;
    }

    public async Task<IReadOnlyList<SelectableWeightClass>> Handle(SelectableWeightClassListQuery _, CancellationToken cancellationToken)
    {
        return await _weightClasses
            .Select(l => new SelectableWeightClass(l.Id, l.Name))
            .ToListAsync(cancellationToken);
    }
}
