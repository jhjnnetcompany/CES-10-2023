using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Bookings.Queries.GetBookings.Models;
public class BookingDetails
{
    public Booking.EntityId BookingId { get; set; } = default!;
    public string OriginName { get; set; } = default!;
    public string DestinationName { get; set; } = default!;
    public DateTimeOffset DepartureDate { get; set; } = default!;
    public DateTimeOffset ArrivalDate { get; set; } = default!;
    public string SizeCategory { get; set; } = default!;
    public int Weight { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string PackageStatus { get; set; } = default!;
}
