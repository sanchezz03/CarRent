using CarRent.Common.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CarRent.Common.ConfigurationOptions;

public class AuthTokenConfigurationOption : IConfigureOptions<AuthTokenConfiguration>
{
    private readonly IConfigurationSection _configurationSection;

    public AuthTokenConfigurationOption(IConfiguration configuration)
    {
        _configurationSection = configuration.GetSection(Constants.CONFIGURATION_SECTION_TOKEN_KEY);
    }

    #region Public methods

    public void Configure(AuthTokenConfiguration options)
    {
        options.TokenKey = _configurationSection?
            .GetValue<string>(nameof(AuthTokenConfiguration.TokenKey)) ??
            string.Empty;
    }

    #endregion
}
