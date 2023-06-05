using System.ComponentModel.DataAnnotations;
using BusinessLayer.Enums;

namespace BusinessLayer.DTOs.BookingDTOs;

public class CreateRoomDTO
{
    /// <summary>
    /// Room type.
    /// </summary>
    /// <example>BasicForTwo</example>
    [Required]
    public RoomType RoomType { get; set; }
}