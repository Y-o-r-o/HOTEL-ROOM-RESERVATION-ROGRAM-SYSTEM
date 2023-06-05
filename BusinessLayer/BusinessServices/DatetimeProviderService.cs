namespace BusinessLayer.BusinessServices;

internal sealed class DateTimeProviderServices : IDateTimeProviderServices
{
    public DateTime DateTimeNow() => DateTime.Now;
}