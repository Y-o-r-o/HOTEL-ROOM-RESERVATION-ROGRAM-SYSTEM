using BusinessLayer.BusinessServices;

namespace UnitTests.BusinessLayerTests.MoqSetups;

public static class DateTimeProviderMoqSetups
{
    public static Mock<IDateTimeProviderServices> Setup_DateTimeNow_ReturnsStartOf2022Year(this Mock<IDateTimeProviderServices> mockDateTimeProvider)
    {
        mockDateTimeProvider
           .Setup(m => m.DateTimeNow())
           .Returns(new DateTime(2022, 1, 1, 0, 0, 0));

        return mockDateTimeProvider;
    }

    public static Mock<IDateTimeProviderServices> Setup_DateTimeNow_ReturnsStartOf2022Year23Hours(this Mock<IDateTimeProviderServices> mockDateTimeProvider)
    {
        mockDateTimeProvider
           .Setup(m => m.DateTimeNow())
           .Returns(new DateTime(2022, 1, 1, 23, 0, 0));

        return mockDateTimeProvider;
    }
}