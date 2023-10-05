﻿using Netcompany.Net.UnitOfWork;
using RoutePlanning.Domain.Categories;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Users;
using RoutePlanning.Domain.WeightClasses;
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
            await SeedLocationsAndRoutes(context);
            await seedCategories(context);
            await seedWeightClasses(context);

            unitOfWork.Commit();
        }
    }

    private static async Task seedWeightClasses(RoutePlanningDatabaseContext context)
    {
        var ltOneKg = new WeightClass("< 1 KG");
        await context.AddAsync(ltOneKg);

        var betweenOneAndFive = new WeightClass("Between 1 and 5 KG");
        await context.AddAsync(betweenOneAndFive);

        var gtOneKg = new WeightClass("> 5 KG");
        await context.AddAsync(gtOneKg);
    }

    private static async Task seedCategories(RoutePlanningDatabaseContext context)
    {
        var fees = new Category("Fee");
        await context.AddAsync(fees);

        var recordedDelivery = new Category("Recorded delivery");
        await context.AddAsync(recordedDelivery);

        var weapons = new Category("Weapons");
        await context.AddAsync(weapons);

        var liveAnimals = new Category("Live Animals");
        await context.AddAsync(liveAnimals);

        var cautiosParcels = new Category("Cautios Parcels");
        await context.AddAsync(cautiosParcels);

        var refridgeratedGoods = new Category("Refridgerated Goods");
        await context.AddAsync(refridgeratedGoods);
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

        CreateTwoWayConnection(tripoli, tanger, 8);
        CreateTwoWayConnection(tanger, marrakesh, 8);
        CreateTwoWayConnection(marrakesh, sierraLeone, 8);
        CreateTwoWayConnection(marrakesh, goldCoast, 8);
        CreateTwoWayConnection(tripoli, goldCoast, 8);
        CreateTwoWayConnection(sierraLeone, stHelena, 8);
        CreateTwoWayConnection(stHelena, capeTown, 8);
        CreateTwoWayConnection(capeTown, whaleBay, 8);
        CreateTwoWayConnection(capeTown, dragonMountain, 8);
        CreateTwoWayConnection(capeTown, amatave, 8);
        CreateTwoWayConnection(capeTown, stMarie, 8);
        CreateTwoWayConnection(dragonMountain, lakeVictoria, 8);
        CreateTwoWayConnection(lakeVictoria, kapSuardafui, 8);
        CreateTwoWayConnection(suakin, darfur, 8);
        CreateTwoWayConnection(suakin, cairo, 8);
        CreateTwoWayConnection(darfur, kabalo, 8);
        CreateTwoWayConnection(tripoli, darfur, 8);
        CreateTwoWayConnection(goldCoast, luanda, 8);
        CreateTwoWayConnection(goldCoast, whaleBay, 8);
        CreateTwoWayConnection(amatave, kapSuardafui, 8);
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

    private static void CreateTwoWayConnection(Location locationA, Location locationB, int distance)
    {
        locationA.AddConnection(locationB, distance);
        locationB.AddConnection(locationA, distance);
    }
}
