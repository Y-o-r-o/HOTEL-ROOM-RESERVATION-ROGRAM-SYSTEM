using System.Text.Json.Serialization;
using BusinessLayer.DependencyInjections;
using Microsoft.Identity.Web;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureSettings(config);
        services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddEndpointsApiExplorer()
                .AddSwaggerExtensions(config);

        services.AddBusinessServices(config);

        return services;
    }
}