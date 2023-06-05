using RepositoryLayer.Databases.Entities.BookingEntities;

namespace UnitTests.BusinessLayerTests.ArrangeTests;

public static class ArrangeResidentEntities
{
    public static IReadOnlyCollection<Resident> GetEntities()
    {
        return new List<Resident>()
        {
            new()
            {
                Id = 1,
                Reservations = new List<Reservation>(),
                Name = "Name1",
                Surname = "Surname1",
                Email = "Email1@mail.com",
                PhoneNumber = "+37062347297"
            },
            new()
            {
                Id = 2,
                Reservations = new List<Reservation>(),
                Name = "Name2",
                Surname = "Surname2",
                Email = "Email2@mail.com",
                PhoneNumber = "+37064347297"
            },
            new()
            {
                Id = 3,
                Reservations = new List<Reservation>(),
                Name = "Name3",
                Surname = "Surname3",
                Email = "Email3@mail.com",
                PhoneNumber = "+37062345297"
            }
        };
    }
}