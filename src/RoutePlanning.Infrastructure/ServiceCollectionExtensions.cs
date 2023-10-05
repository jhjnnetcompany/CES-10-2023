﻿using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Netcompany.Net.DomainDrivenDesign;
using Netcompany.Net.UnitOfWork;
using Netcompany.Net.UnitOfWork.AmbientTransactions;
using RoutePlanning.Infrastructure.Database;

namespace RoutePlanning.Infrastructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRoutePlanningInfrastructure(this IServiceCollection services)
    {
        var keepAliveConnection = new SqliteConnection("DataSource=:memory:"); // change to persistent

        keepAliveConnection.Open();
        services.AddDbContext<RoutePlanningDatabaseContext>(builder =>
        {
            // builder.UseSqlite(keepAliveConnection);
            builder.UseSqlServer("Data Source=tcp:dbs-oa-dk2.database.windows.net,1433;Initial Catalog=db-oa-dk2;User ID=admin-oa-dk2;Password=oceanicFlyAway16");
            builder.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
        });
        
        services.AddDomainDrivenDesign(options => options.UseDbContext<RoutePlanningDatabaseContext>());
        services.AddUnitOfWork(builder => builder.UseAmbientTransactions().With<RoutePlanningDatabaseContext>());

        return services;
    }
}
