using Netcompany.Net.Cqs.Commands;

namespace RoutePlanning.Application.Bookings.Commands.CreateBooking;
public sealed record CreateBookingCommand(
    string OriginName, 
    string DestinationName,
    DateTimeOffset DepartureDate,
    double WeightInKilos, 
    double Height,
    double Depth,
    double Breadth,
    List<string> CategoryNames) : ICommand;
