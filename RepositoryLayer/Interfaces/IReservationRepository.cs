using RepositoryLayer.Databases.Entities.BookingEntities;
using System.Linq.Expressions;

namespace RepositoryLayer.Interfaces;

public interface IReservationRepository
{
    Task<int> CreateReservationAsync(Reservation reservation);
    Task EditReservationAsync(Reservation reservation);
    Task DeleteReservationAsync(Reservation reservation);
    Task<IEnumerable<Reservation>> GetAllReservationsForDateAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Reservation>> GetAllReservationsForRoomAsync(int roomId);
    Task<Reservation?> GetReservationByIdAsync(int reservationId);
    Task<IEnumerable<Reservation>> GetReservationsAsync(Expression<Func<Reservation, bool>>? predicate = null);
    Task<IEnumerable<Reservation>> GetAllReservationsAsync();
}