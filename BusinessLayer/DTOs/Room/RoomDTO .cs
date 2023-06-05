using BusinessLayer.Enums;

namespace BusinessLayer.DTOs.BookingDTOs;

public class RoomDTO
{
    /// <summary>
    /// Room ID.
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }

    public RoomType Type { get; set; }

    public string Number { get; set; }

    public IEnumerable<int> ReservationsIds { get; set; }
}