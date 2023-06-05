using BusinessLayer.Enums;

namespace BusinessLayer.DTOs.BookingDTOs;

public class ReservationDTO
{
    /// <summary>
    /// Reservation ID.
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>
    /// Room ID.
    /// </summary>
    /// <example>[108, 109]</example>
    public IEnumerable<string> RoomsNumbers { get; set; }

    /// <summary>
    /// Room types.
    /// </summary>
    /// <example>[BasicForTwo, VipForTwo]</example>
    public IEnumerable<RoomType> RoomTypes { get; set; }

    /// <summary>
    /// Product additional features
    /// </summary>
    /// <example>[Spa, Pool]</example>
    public IEnumerable<AdditionalFeature> AdditionalFeatures { get; set; }

    public ResidentDTO Resident { get; set; }

    /// <summary>
    /// Reservation start date.
    /// </summary>
    /// <example>2022-10-07T15:00:00</example>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Reservation end date.
    /// </summary>
    /// <example>2022-10-07T16:00:00</example>
    public DateTime EndDate { get; set; }
}