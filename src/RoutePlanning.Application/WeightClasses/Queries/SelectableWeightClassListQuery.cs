using Netcompany.Net.Cqs.Queries;

namespace RoutePlanning.Application.WeightClass.Queries;
public sealed record SelectableWeightClassListQuery : IQuery<IReadOnlyList<SelectableWeightClass>>;
