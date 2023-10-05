using Netcompany.Net.UnitOfWork;
using RoutePlanning.Domain;
using RoutePlanning.Domain.Bookings;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Users;
using RoutePlanning.Infrastructure.Database;

namespace RoutePlanning.Client.Web;

public static class DatabaseInitialization
{
    public static async Task SeedDatabase(WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();

        var context = serviceScope.ServiceProvider.GetRequiredService<RoutePlanningDatabaseContext>();
        await context.Database.EnsureCreatedAsync();

        var unitOfWorkManager = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
        await using (var unitOfWork = unitOfWorkManager.Initiate())
        {
            await SeedUsers(context);
            await SeedCategories(context);
            await SeedLocationsAndRoutes(context);
            await SeedWeightClasses(context);

            unitOfWork.Commit();
        }
    }

    private static async Task CreateSingleBooking(
        RoutePlanningDatabaseContext context,
        Location origin,
        Location destination,
        DateTimeOffset departureDate,
        DateTimeOffset arrivalDate,
        string sizeCategory,
        int weight,
        IEnumerable<ParcelCategory> categories,
        DeliveryStatus packageStatus)
    {
        var booking = new Booking
        {
            Origin = origin,
            Destination = destination,
            DepartureDate = departureDate,
            ArrivalDate = arrivalDate,
            SizeCategory = sizeCategory,
            Weight = weight,
            Categories = categories,
            PackageStatus = packageStatus
        };
        await context.AddAsync(booking);
    }

    private static async Task SeedWeightClasses(RoutePlanningDatabaseContext context)
    {
        var ltOneKg = new ParcelWeight("< 1 KG");
        await context.AddAsync(ltOneKg);

        var betweenOneAndFive = new ParcelWeight("Between 1 and 5 KG");
        await context.AddAsync(betweenOneAndFive);

        var gtOneKg = new ParcelWeight("> 5 KG");
        await context.AddAsync(gtOneKg);
    }

    private static async Task SeedCategories(RoutePlanningDatabaseContext context)
    {
        await CreateParcelCategory(context, "Weapons", 1, true);
        await CreateParcelCategory(context, "Recorded Delivery", 1, false);
        await CreateParcelCategory(context, "Live Animals", 1, false);
        await CreateParcelCategory(context, "Cautious parcels", 0.75, true);
        await CreateParcelCategory(context, "Refrigerated goods", 0.1, true);
    }

    private static async Task SeedLocationsAndRoutes(RoutePlanningDatabaseContext context)
    {
        var cairo = new Location("Cairo");
        await context.AddAsync(cairo);

        var tripoli = new Location("Tripoli");
        await context.AddAsync(tripoli);

        var tunis = new Location("Tunis");
        await context.AddAsync(tunis);

        var marrakesh = new Location("Marrakesh");
        await context.AddAsync(marrakesh);

        var canaryIslands = new Location("Canary island");
        await context.AddAsync(canaryIslands);

        var tanger = new Location("Tanger");
        await context.AddAsync(tanger);

        var sahara = new Location("Sahara");
        await context.AddAsync(sahara);

        var omdurman = new Location("Omdurman");
        await context.AddAsync(omdurman);

        var suakin = new Location("Suakin");
        await context.AddAsync(suakin);

        var addisAbeba = new Location("Addis Abeba");
        await context.AddAsync(addisAbeba);

        var kapSuardafui = new Location("Kap Suardafui");
        await context.AddAsync(kapSuardafui);

        var wadai = new Location("Wadai");
        await context.AddAsync(wadai);

        var sierraLeone = new Location("Sierra Leone");
        await context.AddAsync(sierraLeone);

        var dakar = new Location("Dakar");
        await context.AddAsync(dakar);

        var darfur = new Location("Darfur");
        await context.AddAsync(darfur);

        var timbuktu = new Location("Timbuktu");
        await context.AddAsync(timbuktu);

        var goldCoast = new Location("Gold Coast");
        await context.AddAsync(goldCoast);

        var slaveCoast = new Location("Slave Coast");
        await context.AddAsync(slaveCoast);

        var bahrelGhazal = new Location("Bahrel Ghazal");
        await context.AddAsync(bahrelGhazal);

        var lakeVictoria = new Location("Lake Victoria");
        await context.AddAsync(lakeVictoria);

        var zanzibar = new Location("Zanzibar");
        await context.AddAsync(zanzibar);

        var congo = new Location("Congo");
        await context.AddAsync(congo);

        var kabalo = new Location("Kabalo");
        await context.AddAsync(kabalo);

        var luanda = new Location("Luanda");
        await context.AddAsync(luanda);

        var victoriaFalls = new Location("Victoria Falls");
        await context.AddAsync(victoriaFalls);

        var mocambique = new Location("Mocambique");
        await context.AddAsync(mocambique);

        var stHelena = new Location("St. Helena");
        await context.AddAsync(stHelena);

        var whaleBay = new Location("Whale Bay");
        await context.AddAsync(whaleBay);

        var dragonMountain = new Location("Dragon Mountain");
        await context.AddAsync(dragonMountain);

        var capeTown = new Location("Cape Town");
        await context.AddAsync(capeTown);

        var amatave = new Location("Amatave");
        await context.AddAsync(amatave);

        var stMarie = new Location("St. Marie");
        await context.AddAsync(stMarie);

        var oceanic = new Company("Oceanic Airlines 1");
        await context.AddAsync(oceanic);

        CreateTwoWayConnection(tripoli, tanger, 8, 1, oceanic);
        CreateTwoWayConnection(tanger, marrakesh, 8, 1, oceanic);
        CreateTwoWayConnection(marrakesh, sierraLeone, 8, 1, oceanic);
        CreateTwoWayConnection(marrakesh, goldCoast, 8, 1, oceanic);
        CreateTwoWayConnection(tripoli, goldCoast, 8, 1, oceanic);
        CreateTwoWayConnection(sierraLeone, stHelena, 8, 1, oceanic);
        CreateTwoWayConnection(stHelena, capeTown, 8, 1, oceanic);
        CreateTwoWayConnection(capeTown, whaleBay, 8, 1, oceanic);
        CreateTwoWayConnection(capeTown, dragonMountain, 8, 1, oceanic);
        CreateTwoWayConnection(capeTown, amatave, 8, 1, oceanic);
        CreateTwoWayConnection(capeTown, stMarie, 8, 1, oceanic);
        CreateTwoWayConnection(dragonMountain, lakeVictoria, 8, 1, oceanic);
        CreateTwoWayConnection(lakeVictoria, kapSuardafui, 8, 1, oceanic);
        CreateTwoWayConnection(suakin, darfur, 8, 1, oceanic);
        CreateTwoWayConnection(suakin, cairo, 8, 1, oceanic);
        CreateTwoWayConnection(darfur, kabalo, 8, 1, oceanic);
        CreateTwoWayConnection(tripoli, darfur, 8, 1, oceanic);
        CreateTwoWayConnection(goldCoast, luanda, 8, 1, oceanic);
        CreateTwoWayConnection(goldCoast, whaleBay, 8, 1, oceanic);
        CreateTwoWayConnection(amatave, kapSuardafui, 8, 1, oceanic);

        var parcelCategories = new List<ParcelCategory>
        {
            context.Set<ParcelCategory>().Local.First(),
            context.Set<ParcelCategory>().Local.Last()
        };

        await CreateSingleBooking(context, stMarie, cairo, DateTimeOffset.Now, DateTimeOffset.Now, "Size A", 200,
            parcelCategories, DeliveryStatus.InTransit);
        await CreateSingleBooking(context, darfur, kabalo, DateTimeOffset.Now, DateTimeOffset.Now, "Size A", 200,
            parcelCategories, DeliveryStatus.InTransit);
        await CreateSingleBooking(context, goldCoast, darfur, DateTimeOffset.Now, DateTimeOffset.Now, "Size A", 200,
            parcelCategories, DeliveryStatus.InTransit);
        await CreateSingleBooking(context, stMarie, goldCoast, DateTimeOffset.Now, DateTimeOffset.Now, "Size A", 200,
            parcelCategories, DeliveryStatus.InTransit);
        await CreateSingleBooking(context, cairo, kabalo, DateTimeOffset.Now, DateTimeOffset.Now, "Size A", 200,
            parcelCategories, DeliveryStatus.InTransit);
    }

    private static async Task<ParcelCategory> CreateParcelCategory(RoutePlanningDatabaseContext context, string name, double priceFactor, bool isSupported)
    {
        var newCategory = new ParcelCategory { Name = name, PriceFactor = priceFactor, IsSupported = isSupported };
        return (await context.AddAsync(newCategory)).Entity;
    }

    private static async Task SeedUsers(RoutePlanningDatabaseContext context)
    {
        var dan = new User("dan", User.ComputePasswordHash("dan123!"));
        await context.AddAsync(dan);

        var alice = new User("alice", User.ComputePasswordHash("alice123!"));
        await context.AddAsync(alice);

        var bob = new User("bob", User.ComputePasswordHash("!CapableStudentCries25"));
        await context.AddAsync(bob);
    }

    private static void CreateTwoWayConnection(Location locationA, Location locationB, double timeInHours, double costInDollars, Company company)
    {
        locationA.AddConnection(locationB, timeInHours, costInDollars, company);
        locationB.AddConnection(locationA, timeInHours, costInDollars, company);
    }
}
