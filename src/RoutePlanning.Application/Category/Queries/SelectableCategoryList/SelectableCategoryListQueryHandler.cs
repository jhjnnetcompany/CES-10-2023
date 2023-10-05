using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;

namespace RoutePlanning.Application.Category.Queries.SelectableCategoryList;
public sealed class SelectableCategoryListQueryHandler : IQueryHandler<SelectableCategoryListQuery, IReadOnlyList<SelectableCategory>>
{
    private readonly IQueryable<RoutePlanning.Domain.Categories.Category> _categories;

    public SelectableCategoryListQueryHandler(IQueryable<RoutePlanning.Domain.Categories.Category> categories)
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
