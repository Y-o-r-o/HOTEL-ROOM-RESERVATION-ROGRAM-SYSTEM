using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;
using RepositoryLayer.Repositories.BookingRepositories;

namespace RepositoryLayer.DependencyInjections;

public static class RepositoryServicesExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<BookingDataContext>(options => options.UseSqlServer(config.GetConnectionString("BookingContext")));

        services.AddScoped<IReservationRepository, ReservationRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IResidentRepository, ResidentRepository>()
                .AddScoped<IRoomRepository, RoomRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        return services;
    }
}