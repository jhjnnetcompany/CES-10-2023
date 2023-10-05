using Netcompany.Net.Cqs.Commands;

namespace RoutePlanning.Application.Bookings.Commands.CreateBooking;
public sealed record CreateBookingCommand(
    string OriginName, 
    string DestinationName,
    DateTimeOffset DepartureDate,
    double WeightInKilos, 
    int Height,
    int Depth,
    int Breadth,
    List<string> Categories) : ICommand;
