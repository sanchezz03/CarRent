using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace CarRent.Api.Extensions;

public static class ApiVersionExtension
{
    public static IServiceCollection AddApiVersion(this IServiceCollection services)
    {
        return services
            .AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver")
                );
            });
    }
}