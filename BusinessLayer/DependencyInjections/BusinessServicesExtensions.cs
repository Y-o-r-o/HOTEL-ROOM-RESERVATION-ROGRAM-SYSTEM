using BusinessLayer.BusinessServices;
using BusinessLayer.BusinessServices.BookingServices;
using BusinessLayer.Interfaces;
using BusinessLayer.Interfaces.BookingServices;
using BusinessLayer.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.DependencyInjections;

namespace BusinessLayer.DependencyInjections;

public static class BusinessServicesExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddRepositoryServices(config);

        services.AddIdentityServices();

        services.AddAutoMapper(typeof(MappingProfiles).Assembly);

        services.AddScoped<IReservationServices, ReservationServices>()
                .AddScoped<IProductServices, ProductServices>()
                .AddScoped<IRoomServices, RoomServices>()
                .AddScoped<IResidentServices, ResidentServices>()
                .AddScoped<IDateTimeProviderServices, DateTimeProviderServices>()
                .AddScoped<IRefreshTokenService, RefreshTokenService>()
                .AddScoped<IAccessTokenService, AccessTokenService>()
                .AddScoped<IAuthenticateService, AuthenticateService>()
                .AddScoped<IUserServices, UserServices>();

        return services;
    }
}