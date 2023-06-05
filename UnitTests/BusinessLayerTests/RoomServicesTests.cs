using BusinessLayer.BusinessServices;
using BusinessLayer.BusinessServices.BookingServices;
using BusinessLayer.Enums;
using BusinessLayer.Mappers;
using RepositoryLayer.Interfaces;
using unittests.BusinessLayerTests.ArrangeTests;
using UnitTests.BusinessLayerTests.MoqSetups;

namespace unittests.BusinessLayerTests;

[TestFixture]
public class RoomServicesTests
{
    private MockRepository mockRepository;

    private IMapper _mapper;
    private Mock<IRoomRepository> _mockRoomRepository;
    private Mock<IDateTimeProviderServices> _mockDateTimeServices;

    [SetUp]
    public void SetUp()
    {
        mockRepository = new MockRepository(MockBehavior.Strict);

        var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfiles()));
        _mapper = new Mapper(mapperConfig);

        _mockRoomRepository = mockRepository.Create<IRoomRepository>();
        _mockDateTimeServices = mockRepository.Create<IDateTimeProviderServices>();
    }

    private RoomServices InitializeRoomServices()
    {
        return new RoomServices(
            _mockRoomRepository.Object,
            _mockDateTimeServices.Object,
            _mapper
        );
    }

    [Test]
    [TestCase(0)]
    public async Task CreateRoomAsync_GiveNonExistingRoomName_DoesntThrow(int type)
    {
        // Arrange
        var createRoomDTO = ArrangeRooms.GetValidRoomDTO();

        createRoomDTO.RoomType = (RoomType)type;

        _mockRoomRepository
           .Setup_GetAllRoomsAsync_ReturnsAllRooms()
           .Setup_CreateRoomAsync();

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.CreateRoomAsync(createRoomDTO);

        // Assert
        await action.Should().NotThrowAsync();
    }

    [Test]
    [TestCase(2)]
    [TestCase(5)]
    public async Task DeleteRoomAsync_GiveExistingRoomId_DoesntThrow(int roomId)
    {
        // Arrange
        _mockDateTimeServices
            .Setup_DateTimeNow_ReturnsStartOf2022Year();

        _mockRoomRepository
           .Setup_GetRoomByIdAsync_ReturnsRoomById(roomId)
           .Setup_DeleteRoomAsync();

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.DeleteRoomAsync(roomId);

        // Assert
        await action.Should().NotThrowAsync();
    }

    [Test]
    [TestCase(999)]
    public async Task DeleteRoomAsync_GiveNonExistingRoomId_ThrowRoomNotFound(int roomId)
    {
        // Arrange
        _mockRoomRepository
           .Setup_GetRoomByIdAsync_ReturnsRoomById(roomId)
           .Setup_DeleteRoomAsync();

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.DeleteRoomAsync(roomId);

        // Assert
        await action.Should().ThrowAsync<HttpResponseException>().WithMessage($"Room with this id {roomId} not found.");
    }

    [Test]
    [TestCase(6)]
    public async Task DeleteRoomAsync_GiveExistingRoomIdWithValidReservation_ThrowCantDeleteRoomWithReservations(int roomId)
    {
        // Arrange
        _mockDateTimeServices
            .Setup_DateTimeNow_ReturnsStartOf2022Year();

        _mockRoomRepository
           .Setup_GetRoomByIdAsync_ReturnsRoomById(roomId)
           .Setup_DeleteRoomAsync();

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.DeleteRoomAsync(roomId);

        // Assert
        var ex = (await action.Should().ThrowAsync<ValidationException>()).Which;
        var haveThisMessage = ex.VariableErrors.Value.Any(str => str == "Room with reservations cannot be deleted.");
        haveThisMessage.Should().BeTrue();
    }

    [Test]
    [TestCase(1)]
    public async Task EditRoomAsync_GetExistingRoomsByPredicateNull_DoesntThrow(int roomId)
    {
        // Arrange
        var editRoomDTO = ArrangeRooms.GetValidEditRoomDTO();

        _mockRoomRepository
           .Setup_GetAllRoomsWithoutParamAsync_ReturnsAllRooms()
           .Setup_EditRoomAsync();

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.EditRoomAsync(roomId, editRoomDTO);

        // Assert
        await action.Should().NotThrowAsync();
    }

    [Test]
    [TestCase(500)]
    public async Task EditRoomAsync_GetRoomWithNonExistingRoomId_ThrowNotFound(int roomId)
    {
        // Arrange
        var editRoomDTO = ArrangeRooms.GetValidEditRoomDTO();

        _mockRoomRepository
           .Setup_GetAllRoomsWithoutParamAsync_ReturnsAllRooms()
           .Setup_EditRoomAsync();

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.EditRoomAsync(roomId, editRoomDTO);

        // Assert
        await action.Should().ThrowAsync<HttpResponseException>().WithMessage($"Room with this id {roomId} not found.");
    }

    [Test]
    public async Task GetAllRoomsAsync_GetRoomWithExistingName_DoesntThrow()
    {
        //Arrange
        _mockRoomRepository
           .Setup_GetAllRoomsWithoutParamAsync_ReturnsAllRooms();

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.GetAllRoomsAsync();

        // Assert
        await action.Should().NotThrowAsync();
    }

    [Test]
    public async Task GetAllRoomsAsync_RepositoryReturnsNull_ThrowsNotfound()
    {
        //Arrange
        _mockRoomRepository
           .Setup_GetAllRoomsWithoutParamAsync_ReturnsNoRooms();

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.GetAllRoomsAsync();

        // Assert
        await action.Should().ThrowAsync<HttpResponseException>().WithMessage("No rooms found.");
    }

    [Test]
    [TestCase(6)]
    public async Task GetRoomByIdAsync_GetRoomByIdAsync_DoesntThrow(int roomId)
    {
        //Arrange
        _mockRoomRepository
           .Setup_GetRoomByIdAsync_ReturnsRoomById(roomId);

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.GetRoomByIdAsync(roomId);

        // Assert
        await action.Should().NotThrowAsync();
    }

    [Test]
    [TestCase(797)]
    public async Task GetRoomByIdAsync_GetRoomByIdDoesntExist_ThrowNotFound(int roomId)
    {
        //Arrange
        _mockRoomRepository
           .Setup_GetRoomByIdAsync_ReturnsRoomById(roomId);

        var roomServices = InitializeRoomServices();

        // Act
        var action = () => roomServices.GetRoomByIdAsync(roomId);

        // Assert
        await action.Should().ThrowAsync<HttpResponseException>().WithMessage($"Room with this id {roomId} doesn't exist.");
    }
}