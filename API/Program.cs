using API.Extensions;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;

namespace API;

internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureServices(builder.Configuration);

        var app = builder.Build();
        using var scope = app.Services.CreateScope();

        var servicesProvider = scope.ServiceProvider;
        var bookingContext = servicesProvider.GetRequiredService<BookingDataContext>();

        await bookingContext.Database.MigrateAsync();

        app.Configure(builder.Configuration);

        app.Run();
    }
}