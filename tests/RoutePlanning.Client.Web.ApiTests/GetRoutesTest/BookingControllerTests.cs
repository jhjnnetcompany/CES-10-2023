using MediatR;
using Moq;
using RoutePlanning.Application.Bookings.Commands.CreateBooking;
using RoutePlanning.Application.Bookings.Queries.GetBookings;
using RoutePlanning.Client.Web.Api;

namespace RoutePlanning.Client.Web.ApiTests.GetRoutesTest;
public class BookingControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly BookingController _bookingController;

    public BookingControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _bookingController = new BookingController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetBookings_CallsMediatorWithCommand()
    {
        var command = new GetBookingQuery();

        await _bookingController.GetBookings(command);

        _mediatorMock.Verify(m => m.Send(command, It.IsAny<CancellationToken>()), Moq.Times.Once);
    }

    [Fact]
    public async Task CancelBooking_CallsMediator()
    {
        Guid guid = new("87ef6b05-4636-463f-86f4-178007e99b75");
        var command = new CancelBookingCommand(guid);

        await _bookingController.CancelBooking(command);

        _mediatorMock.Verify(m => m.Send(command, It.IsAny<CancellationToken>()), Moq.Times.Once);
    }

    [Fact]
    public async Task CreateBooking_CallsMediatorWithCreateBookingCommand()
    {

        var command = new CreateBookingCommand("Canary Islands", "Whale Bay", new DateTimeOffset(2008, 5, 1, 8, 6, 32, new TimeSpan(1, 0, 0)), 2, 12, 1, 18, new List<string>() { "Weapons" });

        await _bookingController.CreateBooking(command);

        _mediatorMock.Verify(m => m.Send(command, It.IsAny<CancellationToken>()), Moq.Times.Once);
    }
}
