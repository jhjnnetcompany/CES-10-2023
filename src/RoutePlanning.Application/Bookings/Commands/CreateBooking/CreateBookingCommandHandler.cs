using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Commands;
using Netcompany.Net.DomainDrivenDesign.Services;
using RoutePlanning.Domain.Bookings;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Bookings.Commands.CreateBooking;

public sealed class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand>
{
    private readonly IRepository<Booking> _bookings;
    private readonly IRepository<Location> _locations;
    private readonly IRepository<Category> _categories;

    public CreateBookingCommandHandler(
        IRepository<Booking> bookings,
        IRepository<Location> locations,
        IRepository<Category> categories)
    {
        _bookings = bookings;
        _locations = locations;
        _categories = categories;
    }

    public async Task Handle(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        var originLocation = await _locations
            .SingleAsync(x => x.Name == command.OriginName, cancellationToken);
        var destinationLocation = await _locations
            .SingleAsync(x => x.Name == command.DestinationName, cancellationToken);

        var categories= await _categories
            .Where(x => command.Category.Any(c => c == x.Name))
            .ToListAsync(cancellationToken);

        var newBooking = new Booking
        {
            Categories = categories,
            DepartureDate = command.DepartureDate,
            Destination = destinationLocation,
            Origin = originLocation,
            PackageStatus = "In processing",
            SizeCategory = "A", // TODO: CALCULATE THIS
            Weight = command.WeightInKilos,
        };
        // TODO: REDUCE CAPACITY WHEN WE HAVE A REMAINING VOLUME
        await _bookings.Add(newBooking, cancellationToken);
    }
}
