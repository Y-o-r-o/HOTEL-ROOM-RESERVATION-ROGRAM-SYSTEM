using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;
using UnitTests.BusinessLayerTests.ArrangeTests;

namespace UnitTests.BusinessLayerTests.MoqSetups;

public static class ReservationRepositoryMoqSetups
{
    public static Mock<IReservationRepository> Setup_GetAllReservationsForDateAsync_ReturnsReservationsForDate(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
           .Setup(m => m.GetAllReservationsForDateAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
           .ReturnsAsync((DateTime startDate, DateTime endDate) => ArrangeReservationEntities.GetEntities().Where(r =>
               r.StartDate >= startDate && r.EndDate <= endDate)
           );

        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_GetReservationsAsync_ReturnsReservationsByExpression(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.GetReservationsAsync(It.IsAny<Expression<Func<Reservation, bool>>?>()))
            .ReturnsAsync((Expression<Func<Reservation, bool>>? predicate) =>
                ArrangeReservationEntities.GetEntities().AsQueryable().Where(predicate)
            );

        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_GetAllReservationsAsync_ReturnsAllReservations(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.GetAllReservationsAsync())
            .ReturnsAsync(ArrangeReservationEntities.GetEntities().ToList());

        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_GetAllReservationsAsync_ReturnsEmptyList(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.GetAllReservationsAsync())
            .ReturnsAsync(new List<Reservation>());

        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_GetAllReservationsAsync_ReturnsNull(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.GetAllReservationsAsync())
            .ReturnsAsync((List<Reservation>)null);

        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_CreateReservationAsync(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.CreateReservationAsync(It.IsAny<Reservation>()))
            .ReturnsAsync(0);

        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_GetReservationByIdAsync_ReturnsNull(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.GetReservationByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Reservation?)null);
        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_GetReservationByIdAsync_ReturnsReservation(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.GetReservationByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((int reservationId) => ArrangeReservationEntities.GetEntities().FirstOrDefault(reservation => reservation.Id == reservationId));
        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_EditReservationAsync(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.EditReservationAsync(It.IsAny<Reservation>()))
            .Returns(Task.CompletedTask);
        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_DeleteReservationAsync(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.DeleteReservationAsync(It.IsAny<Reservation>()))
            .Returns(Task.CompletedTask);
        return mockReservationRepository;
    }

    public static Mock<IReservationRepository> Setup_GetAllReservationsForRoomAsync_ReturnsReservationsForRoom(this Mock<IReservationRepository> mockReservationRepository)
    {
        mockReservationRepository
            .Setup(m => m.GetAllReservationsForRoomAsync(It.IsAny<int>()))
            .ReturnsAsync((int roomId) => ArrangeReservationEntities.GetEntities().Where(reservation => reservation.Rooms.Any(r => r.Id == roomId)));
        return mockReservationRepository;
    }
}