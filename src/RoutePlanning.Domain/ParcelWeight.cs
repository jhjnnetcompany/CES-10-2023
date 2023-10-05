using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain;

[DebuggerDisplay("{Name}")]
public sealed class ParcelWeight : Entity<ParcelWeight>
{

    public ParcelWeight(string name, double maxWeight)
    {
        Name = name;
        MaxWeight = maxWeight;
    }

    public string Name { get; set; }
    public double MaxWeight { get; set; }
}
