using API.Controllers.BookingControllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace API.Extensions;

public static class SwaggerServicesExtensions
{
    public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services, IConfiguration c)
    {
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("HotelRoomsV1", new OpenApiInfo { Title = "Hotel Rooms API", Version = "v1" });

            //Configure swagger documentation.
            config.MapType(typeof(TimeSpan), () => new OpenApiSchema { Type = "string" });

            var apiDocumentationPath = Path.Combine(AppContext.BaseDirectory, "API.xml");
            config.IncludeXmlComments(apiDocumentationPath);

            var businesLayerDocumentationPath = Path.Combine(AppContext.BaseDirectory, "BusinessLayer.xml");
            config.IncludeXmlComments(businesLayerDocumentationPath);
            config.AddSecurityDefinition("access", new OpenApiSecurityScheme()
            {
                Description = "Access token",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                   {
                       {
                           new OpenApiSecurityScheme
                           {
                               Reference = new OpenApiReference
                               {
                                   Type = ReferenceType.SecurityScheme,
                                   Id = "access"
                               }
                           },
                           new string[]{}
                       }
                   });
        });

        services.AddSwaggerExamplesFromAssemblies(typeof(RoomController).Assembly);

        return services;
    }
}