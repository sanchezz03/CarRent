using CarRent.Common.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CarRent.Common.ConfigurationOptions;

public class DatabaseConfigurationOption : IConfigureOptions<DatabaseConfiguration>
{
    private readonly IConfigurationSection _configurationSection;

    public DatabaseConfigurationOption(IConfiguration configuration)
    {
        _configurationSection = configuration.GetSection(Constants.CONFIGURATION_SECTION_DATABASE);
    }

    #region Public methods 

    public void Configure(DatabaseConfiguration options)
    {
        options.ConnectionString = _configurationSection?
            .GetValue<string>(nameof(DatabaseConfiguration.ConnectionString)) ??
            string.Empty;
    }

    #endregion
}
