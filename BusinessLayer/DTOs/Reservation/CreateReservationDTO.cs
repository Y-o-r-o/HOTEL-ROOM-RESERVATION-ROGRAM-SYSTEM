using System.ComponentModel.DataAnnotations;
using BusinessLayer.Enums;

namespace BusinessLayer.DTOs.BookingDTOs;

public class CreateReservationDTO
{
    /// <summary>
    /// Room ID.
    /// </summary>
    /// <example>1</example>
    [Required]
    public int ProductId { get; set; }

    /// <summary>
    /// Resident ID.
    /// </summary>
    /// <example>1</example>
    [Required]
    public int ResidentId { get; set; }

    /// <summary>
    /// Reservation start date.
    /// </summary>
    /// <example>2023-10-07T15:00:00</example>
    [Required]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Reservation end date.
    /// </summary>
    /// <example>2023-10-08T16:00:00</example>
    [Required]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Reservation payment token.
    /// </summary>
    /// <example>C55f5s1sFV68I68s88Vv5FG1dd64F4dT4D82</example>
    [Required]
    public string TransactionToken { get; set; }

    /// <summary>
    /// Product additional features
    /// </summary>
    /// <example>[ spa, pool ]</example>
    public IEnumerable<AdditionalFeature> AdditionalFeatures { get; set; }
}