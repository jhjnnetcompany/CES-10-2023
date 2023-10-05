using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.WeightClasses;

[DebuggerDisplay("{Name}")]
public sealed class WeightClass : AggregateRoot<WeightClass>
{
    public WeightClass(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    private readonly List<WeightClass> _weightClasses = new();

    public IReadOnlyCollection<WeightClass> WeightClasses => _weightClasses.AsReadOnly();
}
