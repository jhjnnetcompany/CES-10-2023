using Netcompany.Net.DomainDrivenDesign.Models;

public sealed class Booking : AggregateRoot<Booking>
{
    public Booking(string testAttribute)
    {
        TestAttribute = testAttribute;
    }

    public string TestAttribute { get; set; }
}
