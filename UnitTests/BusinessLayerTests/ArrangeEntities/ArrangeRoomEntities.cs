using RepositoryLayer.Databases.Entities.BookingEntities;
using UnitTests.BusinessLayerTests.ArrangeTests;

namespace UnitTests.BusinessLayerTests.ArrangeEntities;

public class ArrangeRoomEntities
{
    public static IReadOnlyCollection<Room> GetEntities()
    {
        return new List<Room>()
        {
            new()
            {
                Id = 1,
                Type = 0
            },
            new()
            {
                Id = 2,
                Type = 0
            },
            new()
            {
                Id = 3,
                Type = 0
            },
            new()
            {
                Id = 4,
                Type = 0
            },
            new()
            {
                Id = 5,
                Type = 0,
                Reservations = ArrangeReservationEntities.GetEntities().Where(reservation => reservation.Rooms.Any(r => r.Id == 5)).ToList()
            },
            new()
            {
                Id = 6,
                Type = 0,
                Reservations = ArrangeReservationEntities.GetEntities().Where(reservation => reservation.Rooms.Any(r => r.Id == 6)).ToList()
            }
        };
    }
}