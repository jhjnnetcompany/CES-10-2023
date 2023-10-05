using Netcompany.Net.Cqs.Commands;

public sealed record CancelBookingCommand(Guid BookingId) : ICommand;
