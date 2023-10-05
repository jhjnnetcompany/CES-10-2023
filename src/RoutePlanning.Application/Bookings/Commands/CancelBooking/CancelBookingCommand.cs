using Netcompany.Net.Cqs.Commands;
using RoutePlanning.Domain.Locations;

public sealed record CancelBookingCommand(Booking.EntityId BookingId) : ICommand;
