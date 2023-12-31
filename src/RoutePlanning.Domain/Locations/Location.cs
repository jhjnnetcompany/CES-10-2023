﻿using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Name}")]
public sealed class Location : AggregateRoot<Location>
{
    public Location(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    private readonly List<Connection> _connections = new();

    public IReadOnlyCollection<Connection> Connections => _connections.AsReadOnly();

    public Connection AddConnection(Location destination, double timeInHours, double costInDollars, Company owner)
    {
        Connection connection = new(this, destination, timeInHours, costInDollars, owner);
        _connections.Add(connection);
        return connection;
    }
}
