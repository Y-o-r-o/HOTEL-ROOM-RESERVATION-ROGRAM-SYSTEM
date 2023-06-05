using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Enums;

namespace unittests.BusinessLayerTests.ArrangeTests;

public class ArrangeRooms
{
    public static CreateRoomDTO GetValidRoomDTO()
    {
        return new()
        {
            RoomType = RoomType.BasicForTwo
        };
    }

    public static EditRoomDTO GetValidEditRoomDTO()
    {
        return new()
        {
            RoomType = RoomType.BasicForTwo
        };
    }
}