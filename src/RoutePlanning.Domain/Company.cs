using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Name}")]
public sealed class Company : Entity<Company>
{
    public Company(string name)
    {
        Name = name;
    }

    private Company()
    {
        Name = null!;
    }

    public string Name { get; set; }
}
