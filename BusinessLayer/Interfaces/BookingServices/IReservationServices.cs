using BusinessLayer.DTOs;
using BusinessLayer.DTOs.BookingDTOs;

namespace BusinessLayer.Interfaces.BookingServices;

public interface IReservationServices
{
    Task<int> CreateReservationAsync(CreateReservationDTO reservation);
    Task EditReservationAsync(int reservationId, EditReservationDTO reservation);
    Task DeleteReservationAsync(int reservationId);
    Task<IEnumerable<ReservationDTO>> GetAllReservationsForDateAsync(DateOnly startDate, DateOnly endDate);
    Task<IEnumerable<ReservationDTO>> GetAllReservationsForRoomAsync(int roomId);
    Task<ReservationDTO> GetReservationByIdAsync(int reservationId);
    Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync();
    Task<Dictionary<int, IEnumerable<ReservationDataDTO>>> GetMonthReservationsSortedByUserAsync(DateTime dateOnly);
}