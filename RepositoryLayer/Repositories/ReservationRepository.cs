using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.BookingRepositories;

internal sealed class ReservationRepository : IReservationRepository
{
    private readonly BookingDataContext _dataContext;

    public ReservationRepository(BookingDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> CreateReservationAsync(Reservation reservation)
    {
        var result = _dataContext.Reservations.Add(reservation);

        await _dataContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task EditReservationAsync(Reservation reservation)
    {
        _dataContext.Update(reservation);

        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteReservationAsync(Reservation reservation)
    {
        _dataContext.Reservations.Remove(reservation);

        await _dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllReservationsForDateAsync(DateTime startDate, DateTime endDate)
    {
        return await _dataContext.Reservations.Where(r => r.StartDate >= startDate && r.EndDate <= endDate)
            .Include(r => r.Resident).Include(r => r.Rooms).ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllReservationsForRoomAsync(int roomId)
    {
        return await _dataContext.Reservations.Where(r => r.Rooms.Any(r => r.Id == roomId))
            .Include(r => r.Resident).Include(r => r.Rooms).ToListAsync();
    }

    public async Task<Reservation?> GetReservationByIdAsync(int reservationId)
    {
        return await _dataContext.Reservations.Include(r => r.Resident).Include(r => r.Rooms).SingleOrDefaultAsync(r => r.Id == reservationId);
    }

    public async Task<IEnumerable<Reservation>> GetReservationsAsync(Expression<Func<Reservation, bool>>? predicate = null)
    {
        if (predicate == null)
        {
            return await _dataContext.Reservations.Include(r => r.Resident).Include(r => r.Rooms).ToListAsync();
        }

        return await _dataContext.Reservations.Where(predicate).Include(r => r.Resident).Include(r => r.Rooms).ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
    {
        return await _dataContext.Reservations.Include(r => r.Resident).Include(r => r.Rooms).ToListAsync();
    }
}