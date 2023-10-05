
using Microsoft.Extensions.DependencyInjection;
using Netcompany.Net.Cqs;
using Netcompany.Net.Validation;
using RoutePlanning.Domain;

namespace RoutePlanning.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRoutePlanningApplication(this IServiceCollection services)
    {
        services.AddRoutePlanningDomain();

        services.AddCqs();
        services.AddValidation();

        return services;
    }
}
