using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain;

[DebuggerDisplay("{Name}")]
public sealed class Customer : Entity<Customer>
{
    public string Name { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
}
