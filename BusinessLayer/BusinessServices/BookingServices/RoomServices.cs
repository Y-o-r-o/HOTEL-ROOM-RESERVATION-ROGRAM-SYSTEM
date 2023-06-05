using AutoMapper;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Interfaces.BookingServices;
using BusinessLayer.Mappers;
using Core;
using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;
using System.Net;

namespace BusinessLayer.BusinessServices.BookingServices;

internal sealed class RoomServices : IRoomServices
{
    private readonly IRoomRepository _roomRepository;
    private readonly IDateTimeProviderServices _dateTimeProviderServices;
    private readonly IMapper _mapper;

    public RoomServices(IRoomRepository roomRepository, IDateTimeProviderServices dateTimeProviderServices,
        IMapper mapper)
    {
        _roomRepository = roomRepository;
        _dateTimeProviderServices = dateTimeProviderServices;
        _mapper = mapper;
    }

    public async Task<int> CreateRoomAsync(CreateRoomDTO room)
    {
        return await _roomRepository.CreateRoomAsync(_mapper.Map<Room>(room));
    }

    public async Task DeleteRoomAsync(int roomId)
    {
        var roomEntity = await _roomRepository.GetRoomByIdAsync(roomId) ??
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Room with this id {roomId} not found.");

        if (roomEntity.Reservations == null)
        {
            await _roomRepository.DeleteRoomAsync(roomEntity);
            return;
        }

        if (roomEntity.Reservations.Any(r => r.EndDate > _dateTimeProviderServices.DateTimeNow()))
        {
            throw new ValidationException("RoomId", "Room with reservations cannot be deleted.");
        }

        await _roomRepository.DeleteRoomAsync(roomEntity);
    }

    public async Task EditRoomAsync(int roomId, EditRoomDTO room)
    {
        var roomsEntities = await _roomRepository.GetRoomsAsync();

        if (!roomsEntities.Any(r => r.Id == roomId))
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Room with this id {roomId} not found.");
        }

        var roomToEdit = roomsEntities.Where(r => r.Id == roomId).Single();
        roomToEdit.Type = (int)room.RoomType;

        await _roomRepository.EditRoomAsync(roomToEdit);
    }

    public async Task<IEnumerable<RoomDTO>?> GetAllRoomsAsync()
    {
        var roomsEntities = await _roomRepository.GetRoomsAsync() ??
            throw new HttpResponseException(HttpStatusCode.NotFound, "No rooms found.");

        return roomsEntities.MapToRoomsDTO();
    }

    public async Task<RoomDTO> GetRoomByIdAsync(int roomId)
    {
        var roomEntity = await _roomRepository.GetRoomByIdAsync(roomId) ??
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Room with this id {roomId} doesn't exist.");

        return _mapper.Map<RoomDTO>(roomEntity);
    }
}