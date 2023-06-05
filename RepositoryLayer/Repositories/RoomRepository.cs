using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.BookingRepositories;

internal sealed class RoomRepository : IRoomRepository
{
    private readonly BookingDataContext _dataContext;

    public RoomRepository(BookingDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> CreateRoomAsync(Room room)
    {
        var result = _dataContext.Rooms.Add(room);

        await _dataContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task EditRoomAsync(Room room)
    {
        _dataContext.Update(room);

        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteRoomAsync(Room room)
    {
        _dataContext.Rooms.Remove(room);

        await _dataContext.SaveChangesAsync();
    }

    public async Task<Room?> GetRoomByIdAsync(int roomId)
    {
        return await _dataContext.Rooms.Include(r => r.Reservations).ThenInclude(r => r.Resident)
            .SingleOrDefaultAsync(r => r.Id == roomId);
    }

    public async Task<IEnumerable<Room>> GetRoomsAsync(Expression<Func<Room, bool>>? predicate = null)
    {
        if (predicate == null)
        {
            return await _dataContext.Rooms.Include(r => r.Reservations)!
                .ThenInclude(r => r.Resident)!.ToListAsync();
        }

        return await _dataContext.Rooms.Where(predicate).Include(r => r.Reservations)
            .ThenInclude(r => r.Resident).ToListAsync();
    }

    public async Task<IEnumerable<Room>> GetRoomsDataAsync()
    {
        return await _dataContext.Rooms.Include(r => r.Type).ToListAsync();
    }
}