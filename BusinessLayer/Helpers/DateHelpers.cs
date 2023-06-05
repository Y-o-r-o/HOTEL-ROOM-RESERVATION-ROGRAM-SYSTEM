namespace BusinessLayer.Helpers;

internal sealed class DateHelpers
{
    public static int GetCurrentWeekStartDayAsInt(DateTime date)
    {
        int dayOfWeek = (int)date.DayOfWeek;

        return (dayOfWeek + 7) % 8;
    }

    public static DateTime ParseDateOnlyToDateTime(DateOnly date)
    {
        return DateTime.Parse(date.ToString());
    }
}