namespace Core.Extensions;

public static class StringExtensions
{
    public static IEnumerable<int> ConvertToIntList(this string commaSeparatedIntString)
    {
        return commaSeparatedIntString.Equals("") ? new List<int>() : commaSeparatedIntString.Split(',').Select(Int32.Parse).ToList() ?? new List<int>();
    }
}
