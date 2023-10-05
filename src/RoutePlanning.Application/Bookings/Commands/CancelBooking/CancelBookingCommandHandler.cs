using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Commands;
using Netcompany.Net.DomainDrivenDesign.Services;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Bookings.Commands.CancelBooking;

public sealed class GetBookingCommandHandler : ICommandHandler<CancelBookingCommand>
{
    private readonly IRepository<Booking> _bookings;

    public GetBookingCommandHandler(IRepository<Booking> bookings)
    {
        _bookings = bookings;
    }

    public async Task Handle(CancelBookingCommand command, CancellationToken cancellationToken)
    {
        var bookingToRemove = await _bookings.SingleAsync(x => x.Id == command.BookingId, cancellationToken);
        await _bookings.Remove(bookingToRemove, cancellationToken);
    }
}
