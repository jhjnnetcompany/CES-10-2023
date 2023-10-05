using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Categories;

[DebuggerDisplay("{Name}")]
public sealed class Category : AggregateRoot<Category>
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    private readonly List<Category> _categories = new();

    public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();
}
