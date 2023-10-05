using MediatR;
using Microsoft.AspNetCore.Components;
using RoutePlanning.Application.Bookings.Queries.GetBookings;
using RoutePlanning.Application.Bookings.Queries.GetBookings.Models;

namespace RoutePlanning.Client.Web.Pages;

public sealed partial class OverviewPage
{

    [Inject]
    private IMediator Mediator { get; set; } = default!;

    public IEnumerable<BookingDetails> _bookings = new List<BookingDetails>();

    private List<BookingDetails> SortedBookings = new();

    protected override async Task OnInitializedAsync()
    {
        await UpdateBookingList();
    }

    private async Task UpdateBookingList()
    {
        _bookings = await Mediator.Send(new GetBookingQuery(), CancellationToken.None);
        SortedBookings = new List<BookingDetails>(_bookings);
    }

    private async Task CancelBooking(BookingDetails bookingDetails)
    {
        await Mediator.Send(new CancelBookingCommand(bookingDetails.BookingId), CancellationToken.None);
        await UpdateBookingList();
    }
}
