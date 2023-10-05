using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain;

[DebuggerDisplay("{Name}")]
public sealed class ParcelWeight : Entity<ParcelWeight>
{
    public ParcelWeight(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
