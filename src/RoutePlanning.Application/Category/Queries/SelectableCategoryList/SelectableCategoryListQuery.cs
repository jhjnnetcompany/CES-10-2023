using Netcompany.Net.Cqs.Queries;

namespace RoutePlanning.Application.Category.Queries.SelectableCategoryList;

public sealed record SelectableCategoryListQuery : IQuery<IReadOnlyList<SelectableCategory>>;
