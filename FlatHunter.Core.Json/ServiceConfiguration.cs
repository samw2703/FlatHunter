using Microsoft.Extensions.DependencyInjection;

namespace FlatHunter.Core.Json;

public static class ServiceConfiguration
{
    public static void AddJsonServices(this IServiceCollection services)
    {
        services.AddScoped<IPropertyRepository, PropertyRespository>();
    }
}