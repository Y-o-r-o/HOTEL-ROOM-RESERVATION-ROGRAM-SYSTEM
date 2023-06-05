using BusinessLayer.DTOs.BookingDTOs;

namespace BusinessLayer.Interfaces.BookingServices;

public interface IRoomServices
{
    Task<int> CreateRoomAsync(CreateRoomDTO room);
    Task EditRoomAsync(int roomId, EditRoomDTO room);
    Task DeleteRoomAsync(int roomId);
    Task<RoomDTO> GetRoomByIdAsync(int roomId);
    Task<IEnumerable<RoomDTO>?> GetAllRoomsAsync();
}