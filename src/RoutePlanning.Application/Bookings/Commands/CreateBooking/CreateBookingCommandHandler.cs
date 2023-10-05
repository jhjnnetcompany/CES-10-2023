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

        var categories= await _categories
            .Where(x => command.Categories.Any(c => c == x.Name))
            .ToListAsync(cancellationToken);

        var newBooking = new Booking
        {
            Categories = categories,
            DepartureDate = command.DepartureDate,
            Destination = destinationLocation,
            Origin = originLocation,
            PackageStatus = DeliveryStatus.Booked,
            SizeCategory = "A", // TODO: CALCULATE THIS
            Weight = command.WeightInKilos,
        };
        // TODO: REDUCE CAPACITY WHEN WE HAVE A REMAINING VOLUME
        await _bookings.Add(newBooking, cancellationToken);
    }
}
