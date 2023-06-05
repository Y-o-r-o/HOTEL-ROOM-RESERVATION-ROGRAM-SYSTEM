using RepositoryLayer.Databases.Entities.BookingEntities;
using System.Linq.Expressions;

namespace RepositoryLayer.Interfaces;

public interface IRoomRepository
{
    Task<int> CreateRoomAsync(Room room);
    Task EditRoomAsync(Room room);
    Task DeleteRoomAsync(Room room);
    Task<Room?> GetRoomByIdAsync(int roomId);
    Task<IEnumerable<Room>> GetRoomsAsync(Expression<Func<Room, bool>>? predicate = null);
    Task<IEnumerable<Room>> GetRoomsDataAsync();
}