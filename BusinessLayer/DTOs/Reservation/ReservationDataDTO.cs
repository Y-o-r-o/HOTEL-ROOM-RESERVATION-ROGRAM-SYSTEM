using BusinessLayer.Enums;

namespace BusinessLayer.DTOs.BookingDTOs;

public class ReservationDataDTO
{
    /// <summary>
    /// Resident that rented room Id.
    /// </summary>
    /// <example>1</example>
    public int ResidentId { get; set; }

    /// <summary>
    /// Room name.
    /// </summary>
    /// <example>[BasicForTwo, VipForTwo]</example>
    public IEnumerable<RoomType> RoomsTypes { get; set; }

    /// <summary>
    /// Reservation date.
    /// </summary>
    /// <example>2022-10-01</example>
    public string Date { get; set; }

    /// <summary>
    /// Reservation duration.
    /// </summary>
    /// <example>01:00:00</example>
    public TimeSpan Duration { get; set; }
}