using CarRent.Common.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarRent.Application.Extensions;

public static class MappingExtension
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var profiles = TypesHelper.GetTypesFromAllAssemblies<AutoMapper.Profile>();
        var assemblies = new List<Assembly> { Assembly.GetCallingAssembly() };
        assemblies.AddRange(profiles.Select(x => x.Assembly).Distinct());
        return services.AddAutoMapper(assemblies.ToArray());
    }
}
