using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs.BookingDTOs;

public class EditReservationDTO
{
    /// <summary>
    /// Reservation start date.
    /// </summary>
    /// <example>2023-10-07T15:00:00</example>
    [Required]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Reservation end date.
    /// </summary>
    /// <example>2023-10-07T16:00:00</example>
    [Required]
    public DateTime EndDate { get; set; }
}