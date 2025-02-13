using CarRent.Api.Services;
using CarRent.Common.ConfigurationModels;
using CarRent.Common.ConfigurationOptions;
using CarRent.Domain.Entities;
using CarRent.Infrastructure.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarRent.Api.Extensions;

public static class IdentityServiceExtension
{

    #region Public methods 

    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.ConfigureOptions();

        services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
            opt.User.RequireUniqueEmail = true;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>();

        var option = services.BuildServiceProvider().GetRequiredService<IOptions<AuthTokenConfiguration>>();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(option.Value.TokenKey));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        services.AddScoped<TokenService>();

        return services;
    }

    #endregion

    #region Private methods

    private static IServiceCollection ConfigureOptions(this IServiceCollection services)
    {
        return services.AddTransient<IConfigureOptions<AuthTokenConfiguration>, AuthTokenConfigurationOption>();
    }

    #endregion
}
