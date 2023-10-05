using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Domain;

namespace RoutePlanning.Application.Category.Queries.SelectableCategoryList;
public sealed class SelectableCategoryListQueryHandler : IQueryHandler<SelectableCategoryListQuery, IReadOnlyList<SelectableCategory>>
{
    private readonly IQueryable<ParcelCategory> _categories;

    public SelectableCategoryListQueryHandler(IQueryable<ParcelCategory> categories)
    {
        _categories = categories;
    }

    public async Task<IReadOnlyList<SelectableCategory>> Handle(SelectableCategoryListQuery _, CancellationToken cancellationToken)
    {
        return await _categories
            .Select(l => new SelectableCategory(l.Id, l.Name))
            .ToListAsync(cancellationToken);
    }
}
