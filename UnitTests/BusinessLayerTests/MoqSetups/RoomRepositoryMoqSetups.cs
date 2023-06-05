using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;
using UnitTests.BusinessLayerTests.ArrangeEntities;

namespace UnitTests.BusinessLayerTests.MoqSetups;

public static class RoomRepositoryMoqSetups
{
    public static Mock<IRoomRepository> Setup_GetAllRoomsAsync_ReturnsAllRooms(this Mock<IRoomRepository> mockRoomRepository)
    {
        mockRoomRepository
           .Setup(m => m.GetRoomsAsync(It.IsAny<Expression<Func<Room, bool>>?>()))
           .ReturnsAsync((Expression<Func<Room, bool>>? predicate) => ArrangeRoomEntities.GetEntities().AsQueryable().Where(predicate)
           );

        return mockRoomRepository;
    }

    public static Mock<IRoomRepository> Setup_GetAllRoomsWithoutParamAsync_ReturnsAllRooms(this Mock<IRoomRepository> mockRoomRepository)
    {
        mockRoomRepository
           .Setup(m => m.GetRoomsAsync(null))
           .ReturnsAsync(ArrangeRoomEntities.GetEntities());

        return mockRoomRepository;
    }

    public static Mock<IRoomRepository> Setup_GetAllRoomsWithoutParamAsync_ReturnsNoRooms(this Mock<IRoomRepository> mockRoomRepository)
    {
        mockRoomRepository
           .Setup(m => m.GetRoomsAsync(null))
           .ReturnsAsync(value: null);

        return mockRoomRepository;
    }

    public static Mock<IRoomRepository> Setup_CreateRoomAsync(this Mock<IRoomRepository> mockRoomRepository)
    {
        mockRoomRepository
           .Setup(m => m.CreateRoomAsync(It.IsAny<Room>()))
           .ReturnsAsync(0);

        return mockRoomRepository;
    }

    public static Mock<IRoomRepository> Setup_GetRoomByIdAsync_ReturnsRoomById(this Mock<IRoomRepository> mockRoomRepository, int roomId)
    {
        mockRoomRepository
            .Setup(m => m.GetRoomByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(ArrangeRoomEntities.GetEntities().FirstOrDefault(r => r.Id == roomId));

        return mockRoomRepository;
    }

    public static Mock<IRoomRepository> Setup_DeleteRoomAsync(this Mock<IRoomRepository> mockRoomRepository)
    {
        mockRoomRepository
            .Setup(m => m.DeleteRoomAsync(It.IsAny<Room>())).
            Returns(Task.CompletedTask);

        return mockRoomRepository;
    }

    public static Mock<IRoomRepository> Setup_GetRoomsData(this Mock<IRoomRepository> mockRoomRepository)
    {
        mockRoomRepository
            .Setup(m => m.GetRoomsDataAsync()).
            ReturnsAsync(ArrangeRoomEntities.GetEntities().ToList());

        return mockRoomRepository;
    }

    public static Mock<IRoomRepository> Setup_EditRoomAsync(this Mock<IRoomRepository> mockRoomRepository)
    {
        mockRoomRepository
            .Setup(m => m.EditRoomAsync(It.IsAny<Room>())).
            Returns(Task.CompletedTask);

        return mockRoomRepository;
    }
}