using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Application.Bookings.Queries.GetBookings.Models;

namespace RoutePlanning.Application.Bookings.Queries.GetBookings;
public sealed record GetBookingQuery() : IQuery<IEnumerable<BookingDetails>>;
