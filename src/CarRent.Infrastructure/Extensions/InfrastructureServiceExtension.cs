using Microsoft.Extensions.DependencyInjection;
using CarRent.Domain.Abstractions.Repositories;
using CarRent.Infrastructure.Abstractions.Repositories;

namespace CarRent.Infrastructure.Extensions;

public static class InfrastructureServiceExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services
            //Repositories
            .AddScoped<ICarRepository, CarRepository>();
    }
}
