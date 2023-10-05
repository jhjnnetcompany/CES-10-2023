using Netcompany.Net.Cqs.Commands;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;

public sealed record CreateTwoWayConnectionCommand(Location.EntityId LocationAId, Location.EntityId LocationBId, double TimeInHours, double CostInDollars, Company owner) : ICommand;
