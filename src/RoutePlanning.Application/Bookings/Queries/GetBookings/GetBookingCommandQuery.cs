using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;
using Netcompany.Net.DomainDrivenDesign.Services;
using RoutePlanning.Application.Bookings.Queries.GetBookings.Models;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Bookings.Queries.GetBookings;

public sealed class GetBookingCommandQuery : IQueryHandler<GetBookingQuery, IEnumerable<BookingDetails>>
{
    private readonly IRepository<Booking> _bookings;

    public GetBookingCommandQuery(IRepository<Booking> bookings)
    {
        _bookings = bookings;
    }

    public async Task<IEnumerable<BookingDetails>> Handle(GetBookingQuery command, CancellationToken cancellationToken)
    {
        return await _bookings.Select(x => new BookingDetails
        {
            BookingId = x.Id,
            OriginName = x.Origin.Name,
            DepartureDate = x.DepartureDate,
            DestinationName = x.Destination.Name,
            ArrivalDate = x.ArrivalDate,
            Category = x.Category,
            PackageStatus = x.PackageStatus,
            SizeCategory = x.SizeCategory,
            Weight = x.Weight
        }).ToListAsync(cancellationToken);
    }
}
