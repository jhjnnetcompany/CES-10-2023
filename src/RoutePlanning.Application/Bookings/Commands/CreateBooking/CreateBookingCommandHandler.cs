using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Commands;
using Netcompany.Net.DomainDrivenDesign.Services;
using RoutePlanning.Domain;
using RoutePlanning.Domain.Bookings;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Bookings.Commands.CreateBooking;

public sealed class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand>
{
    private readonly IRepository<Booking> _bookings;
    private readonly IRepository<Location> _locations;
    private readonly IQueryable<ParcelCategory> _categories;

    public CreateBookingCommandHandler(
        IRepository<Booking> bookings,
        IRepository<Location> locations,
        IQueryable<ParcelCategory> categories)
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

        var categories = await _categories
            .Where(x => command.CategoryNames.Any(c => c == x.Name))
            .AsTracking()
            .ToListAsync(cancellationToken);

        var newBooking = new Booking
        {
            Origin = originLocation,
            SizeCategory = "Size A",
            Weight = command.WeightInKilos,
            PackageStatus = DeliveryStatus.Booked,
            Destination = destinationLocation,
            Categories = categories,
        };

        await _bookings.Add(newBooking, cancellationToken);
    }
}
