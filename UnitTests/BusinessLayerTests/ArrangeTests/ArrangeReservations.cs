using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Enums;

namespace UnitTests.BusinessLayerTests.ArrangeTests;

public class ArrangeReservations
{
    public static CreateReservationDTO GetValidCreateReservationDTO()
    {
        return new()
        {
            ResidentId = 1,
            ProductId = 1,
            StartDate = new DateTime(2023, 1, 3, 6, 0, 0),
            EndDate = new DateTime(2023, 1, 3, 7, 0, 0),
            TransactionToken = "abaaba",
            AdditionalFeatures = new HashSet<AdditionalFeature>()
        };
    }

    public static EditReservationDTO GetValidEditReservationDTO()
    {
        return new()
        {
            StartDate = new DateTime(2023, 1, 3, 6, 0, 0),
            EndDate = new DateTime(2023, 1, 3, 7, 0, 0)
        };
    }
}