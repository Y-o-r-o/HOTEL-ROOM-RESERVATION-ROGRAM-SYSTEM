using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Enums;

namespace UnitTests.BusinessLayerTests.ArrangeTests;

public class ArrangeReservationsData
{
    public static Dictionary<Guid, IReadOnlyCollection<ReservationDataDTO>> GetValidReservationsData()
    {
        return new()
        {
            {
                new("2ecb003d-5f09-4f81-82f7-ee7388165432"),
                new List<ReservationDataDTO>()
                {
                    new()
                    {
                        ResidentId = 1,
                        RoomsTypes = new List<RoomType>()
                        {
                            RoomType.BasicForTwo
                        },
                        Date = new DateTime(2022, 10, 07).ToShortDateString(),
                        Duration = new(1, 0, 0),
                    },
                    new()
                    {
                        ResidentId = 1,
                        RoomsTypes = new List<RoomType>()
                        {
                            RoomType.BasicForTwo
                        },
                        Date = new DateTime(2022, 10, 07).ToShortDateString(),
                        Duration = new(1, 0, 0),
                    },
                    new()
                    {
                        ResidentId = 1,
                        RoomsTypes = new List<RoomType>()
                        {
                            RoomType.BasicForTwo
                        },
                        Date = new DateTime(2022, 10, 07).ToShortDateString(),
                        Duration = new(1, 0, 0),
                    }
                }
            },
            {
                new("00000000-0000-0000-0000-000000000001"),
                new List<ReservationDataDTO>()
                {
                    new()
                    {
                        ResidentId = 1,
                        RoomsTypes = new List<RoomType>()
                        {
                            RoomType.BasicForTwo
                        },
                        Date = new DateTime(2022, 10, 07).ToShortDateString(),
                        Duration = new(1, 0, 0),
                    }
                }
            },
            {
                new("00000000-0000-0000-0000-000000000002"),
                new List<ReservationDataDTO>()
                {
                    new()
                    {
                        ResidentId = 1,
                        RoomsTypes = new List<RoomType>()
                        {
                            RoomType.BasicForTwo
                        },
                        Date = new DateTime(2022, 10, 07).ToShortDateString(),
                        Duration = new(0, 1, 0),
                    }
                }
            },
            {
                new("00000000-0000-0000-0000-000000000003"),
                new List<ReservationDataDTO>()
                {
                    new()
                    {
                        ResidentId = 1,
                        RoomsTypes = new List<RoomType>()
                        {
                            RoomType.BasicForTwo
                        },
                        Date = new DateTime(2022, 10, 07).ToShortDateString(),
                        Duration = new(0, 1, 0),
                    }
                }
            },
            {
                new("00000000-0000-0000-0000-000000000005"),
                new List<ReservationDataDTO>()
                {
                    new()
                    {
                        ResidentId = 1,
                        RoomsTypes = new List<RoomType>()
                        {
                            RoomType.BasicForTwo
                        },
                        Date = new DateTime(2022, 10, 07).ToShortDateString(),
                        Duration = new(1, 0, 0),
                    }
                }
            }
        };
    }
}