using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutePlanning.Application.Bookings.Commands.CreateBooking;
using RoutePlanning.Client.Web.Authorization;

namespace RoutePlanning.Client.Web.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(nameof(TokenRequirement))]
public sealed class BookingController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task GetBookings(CancelBookingCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpPost("[action]")]
    public async Task CancelBooking([FromBody] CancelBookingCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpPost("[action]")]
    public async Task CreateBooking([FromBody] CreateBookingCommand command)
    {
        await _mediator.Send(command);
    }
}
