using RepositoryLayer.Databases.Entities.BookingEntities;

namespace UnitTests.BusinessLayerTests.ArrangeTests;

public static class ArrangeReservationEntities
{
    public static IReadOnlyCollection<Reservation> GetEntities()
    {
        return new List<Reservation>()
        {
            new()
            {
                Id = 1,
                Rooms = new List<Room>(),
                Resident = new(),
                StartDate = new(2022, 10, 7, 14, 0, 0),
                EndDate = new(2022, 10, 7, 15, 0, 0)
            },
            new()
            {
                Id = 2,
                Rooms = new List<Room>(),
                Resident = new(),
                StartDate = new(2022, 10, 7, 16, 0, 0),
                EndDate = new(2022, 10, 7, 17, 0, 0),
            },
            new()
            {
                Id = 3,
                Rooms = new List<Room>(),
                Resident = new(),
                StartDate = new(2022, 10, 7, 17, 0, 0),
                EndDate = new(2022, 10, 7, 18, 0, 0)
            },
            new()
            {
                Id = 4,
                Rooms = new List<Room>(),
                Resident = new(),
                StartDate = new(2022, 10, 7, 18, 0, 0),
                EndDate = new(2022, 10, 7, 18, 1, 0)
            },
            new()
            {
                Id = 5,
                Rooms = new List<Room>(),
                Resident = new(),
                StartDate = new(2022, 10, 7, 18, 3, 0),
                EndDate = new(2022, 10, 7, 18, 4, 0)
            },
            new()
            {
                Id = 6,
                Rooms = new List<Room>(),
                Resident = new(),
                EndDate = new(2024, 10, 7, 18, 4, 0),
            },
            new()
            {
                Id = 7,
                Rooms = new List<Room>(),
                Resident = new(),
                StartDate = new(2021, 10, 7, 14, 0, 0),
                EndDate = new(2021, 10, 7, 15, 0, 0),
            },
            new()
            {
                Id = 8,
                Rooms = new List<Room>()
                {
                    new ()
                    {
                        Id = 6,
                        Type = 0,
                    }
                },
                Resident = new(),
                StartDate = new(2022, 10, 7, 14, 0, 0),
                EndDate = new(2022, 10, 7, 15, 0, 0)
            },
            new()
            {
                Id = 9,
                Rooms = new List<Room>(),
                Resident = new(),
                StartDate = new(2022, 10, 7, 12, 0, 0),
                EndDate = new(2022, 10, 7, 13, 0, 0),
            }
        };
    }
}