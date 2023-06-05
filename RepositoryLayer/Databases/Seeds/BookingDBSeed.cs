using RepositoryLayer.Databases.Entities.BookingEntities;

namespace RepositoryLayer.Databases.Seeds;

public sealed class BookingDBSeed
{
    public static IEnumerable<Room> RoomsDataSeed()
    {
        IEnumerable<Room> rooms = new List<Room>
        {
            new Room()
            {
                Id = 1,
                Number = "101",
                Type = 0,
            },
            new Room()
            {
                Id = 2,
                Number = "102",
                Type = 0,
            },
            new Room()
            {
                Id = 3,
                Number = "103",
                Type = 0,
            },
            new Room()
            {
                Id = 4,
                Number = "104",
                Type = 0,
            },
            new Room()
            {
                Id = 5,
                Number = "105",
                Type = 0,
            },
            new Room()
            {
                Id = 6,
                Number = "106",
                Type = 0,
            },
            new Room()
            {
                Id = 7,
                Number = "107",
                Type = 0,
            },
            new Room()
            {
                Id = 8,
                Number = "108",
                Type = 0,
            },
            new Room()
            {
                Id = 9,
                Number = "109",
                Type = 0,
            },
            new Room()
            {
                Id = 10,
                Number = "110",
                Type = 0,
            },
            new Room()
            {
                Id = 11,
                Number = "201",
                Type = 1,
            },
            new Room()
            {
                Id = 12,
                Number = "202",
                Type = 1,
            },
            new Room()
            {
                Id = 13,
                Number = "203",
                Type = 1,
            },
            new Room()
            {
                Id = 14,
                Number = "204",
                Type = 1,
            },
            new Room()
            {
                Id = 15,
                Number = "205",
                Type = 1,
            },
            new Room()
            {
                Id = 16,
                Number = "206",
                Type = 1,
            },
            new Room()
            {
                Id = 17,
                Number = "207",
                Type = 1,
            },
            new Room()
            {
                Id = 18,
                Number = "208",
                Type = 1,
            },
            new Room()
            {
                Id = 19,
                Number = "209",
                Type = 1,
            },
            new Room()
            {
                Id = 20,
                Number = "210",
                Type = 1,
            },
            new Room()
            {
                Id = 21,
                Number = "301",
                Type = 2,
            },
            new Room()
            {
                Id = 22,
                Number = "302",
                Type = 2,
            },
            new Room()
            {
                Id = 23,
                Number = "303",
                Type = 2,
            },
            new Room()
            {
                Id = 24,
                Number = "304",
                Type = 2,
            },
            new Room()
            {
                Id = 25,
                Number = "305",
                Type = 2,
            },
            new Room()
            {
                Id = 26,
                Number = "306",
                Type = 2,
            },
            new Room()
            {
                Id = 27,
                Number = "307",
                Type = 2,
            },
            new Room()
            {
                Id = 28,
                Number = "308",
                Type = 2,
            },
            new Room()
            {
                Id = 29,
                Number = "309",
                Type = 2,
            },
            new Room()
            {
                Id = 30,
                Number = "310",
                Type = 2,
            },
            new Room()
            {
                Id = 31,
                Number = "401",
                Type = 3,
            },
            new Room()
            {
                Id = 32,
                Number = "402",
                Type = 3,
            },
            new Room()
            {
                Id = 33,
                Number = "403",
                Type = 4,
            },
            new Room()
            {
                Id = 34,
                Number = "404",
                Type = 3,
            },
            new Room()
            {
                Id = 35,
                Number = "405",
                Type = 3,
            },
            new Room()
            {
                Id = 36,
                Number = "406",
                Type = 3,
            },
            new Room()
            {
                Id = 37,
                Number = "407",
                Type = 3,
            },
            new Room()
            {
                Id = 38,
                Number = "408",
                Type = 3,
            },
            new Room()
            {
                Id = 39,
                Number = "409",
                Type = 3,
            },
            new Room()
            {
                Id = 40,
                Number = "410",
                Type = 3,
            },
            new Room()
            {
                Id = 41,
                Number = "501",
                Type = 4,
            },
            new Room()
            {
                Id = 42,
                Number = "502",
                Type = 4,
            },
            new Room()
            {
                Id = 43,
                Number = "503",
                Type = 4,
            },
            new Room()
            {
                Id = 44,
                Number = "504",
                Type = 4,
            },
            new Room()
            {
                Id = 45,
                Number = "505",
                Type = 4,
            },
            new Room()
            {
                Id = 46,
                Number = "506",
                Type = 4,
            },
            new Room()
            {
                Id = 47,
                Number = "507",
                Type = 4,
            },
            new Room()
            {
                Id = 48,
                Number = "508",
                Type = 4,
            },
            new Room()
            {
                Id = 49,
                Number = "509",
                Type = 4,
            },
            new Room()
            {
                Id = 50,
                Number = "510",
                Type = 4,
            }
        };
        return rooms;
    }

    public static IEnumerable<Reservation> ReservationsDataSeed()
    {
        IEnumerable<Reservation> reservations = new List<Reservation>
        {
            
        };
        return reservations;
    }

    public static IEnumerable<Resident> ResidentsDataSeed()
    {
        IEnumerable<Resident> residents = new List<Resident>
        {
            new Resident()
            {
                Id = 1,
                Name = "Gyventojas",
                Surname = "Vienas",
                Email = "Gyventojas.Vienas@mail.com",
                PhoneNumber = "+37062347291"
            },
            new Resident()
            {
                Id = 2,
                Name = "Gyventojas",
                Surname = "Du",
                Email = "Gyventojas.Du@mail.com",
                PhoneNumber = "+37062347292"
            },
            new Resident()
            {
                Id = 3,
                Name = "Gyventojas",
                Surname = "Trys",
                Email = "Gyventojas.Trys@mail.com",
                PhoneNumber = "+37062347293"
            },
            new Resident()
            {
                Id = 4,
                Name = "Gyventojas",
                Surname = "Keturi",
                Email = "Gyventojas.Keturi@mail.com",
                PhoneNumber = "+37062347294"
            },
        };
        return residents;
    }
}