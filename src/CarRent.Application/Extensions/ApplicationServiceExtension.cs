using CarRent.Application.Services;
using CarRent.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CarRent.Application.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ICarService, CarService>()
            .AddScoped<IBookingService, BookingService>()
            .AddScoped<IPaymentService, PaymentService>();
    }
}
