﻿using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Domain.Bookings;

public sealed class Booking : AggregateRoot<Booking>
{
    public Location Origin { get; set; } = default!;
    public Location Destination { get; set; } = default!;
    public DateTimeOffset DepartureDate { get; set; } = default!;
    public DateTimeOffset ArrivalDate { get; set; } = default!;
    public string SizeCategory { get; set; } = default!;
    public double Weight { get; set; } = default!;
    public DeliveryStatus PackageStatus { get; set; }
    public IEnumerable<ParcelCategory> Categories { get; set; } = default!;
}
