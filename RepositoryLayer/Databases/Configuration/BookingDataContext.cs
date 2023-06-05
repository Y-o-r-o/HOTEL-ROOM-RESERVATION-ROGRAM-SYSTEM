using Core.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Databases.Seeds;

namespace RepositoryLayer.Databases.Configuration;

public sealed class BookingDataContext  : IdentityDbContext<AppUser>
{
    public BookingDataContext(DbContextOptions<BookingDataContext> options) 
        : base(options) {}

    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Resident> Residents { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Payment> Payment { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Reservation>().HasData(BookingDBSeed.ReservationsDataSeed());
        builder.Entity<Room>().HasData(BookingDBSeed.RoomsDataSeed());
        builder.Entity<Resident>().HasData(BookingDBSeed.ResidentsDataSeed());

        builder
            .Entity<Reservation>()
            .Property(rs => rs.AdditionalFeatures)
            .HasConversion(
                toDb => toDb.ConvertToString(), 
                fromDb => fromDb.ConvertToIntList());
                
        builder.Entity<Reservation>().HasMany(rs => rs.Rooms).WithMany("Reservations");
        
        builder.Entity<Resident>().HasMany(r => r.Reservations).WithOne(rs => rs.Resident);
    
        builder
            .Entity<Product>()
            .Property(p => p.RoomsTypes)
            .HasConversion(
                toDb => toDb.ConvertToString(), 
                fromDb => fromDb.ConvertToIntList());
                
        builder
            .Entity<Product>()
            .Property(p => p.AdditionalFeatures)
            .HasConversion(
                toDb => toDb.ConvertToString(), 
                fromDb => fromDb.ConvertToIntList());

        base.OnModelCreating(builder);
    }
}