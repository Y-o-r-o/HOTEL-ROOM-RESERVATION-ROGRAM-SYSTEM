using BusinessLayer.Configuration;
using BusinessLayer.Enums;

namespace BusinessLayer.Helpers;

internal static class Constants
{
    public const int WORKING_DAY_START_HOUR = 6;
    public const int WORKING_DAY_END_HOUR = 19;
    public const int RESERVATION_COUNT_LIMIT = 2;
    public const int WEEK_LENGTH = 7;
    public const int ONE_DAY = 1;
    public const int ONE_SECOND = 1;
    public const string VALID_TEST_MESSAGE = "Test is valid.";
    public const string EXPIRED_OR_COMPLETED_TEST_MESSAGE = "Test is expired or already completed.";
    public const string TIME_EXPIRED_TEST_MESSAGE = "You didn't complete test in time.";
    public const string DATE_EXPIRED_TEST_MESSAGE = "Test expired.";
    public const string RESULT_TEST_MESSAGE = "This is test result";
    public static readonly Dictionary<PropertyIs, PropertyValidationConfiguration> PROPERTY_VALIDATIONS = new()
    {
        {PropertyIs.Default, new("^[A-Za-z0-9- \\p{L},._-|]+$", "should only consist of letters, numbers or symbols `,`, `.`, `-`, `_`, `|`.", 20, 6)},
        {PropertyIs.HumanName, new("^[_a-zA-Z \\p{L}_-]+$", "should only consist of letters or symbols `-`, `_`.", 20, 6)},
        {PropertyIs.ItemName, new("^[_a-zA-Z0-9- \\p{L}_-]+$", "should only consist of letters, numbers or symbols `-`, `_`.", 20, 6)},
        {PropertyIs.Title, new("^[A-Za-z0-9- \\p{L},._-|]+$", "should only consist of letters, numbers or symbols `,`, `.`, `-`, `_`, `|`.", 40, 6)},
        {PropertyIs.Email, new("^[^@\\s%$#/|]+@[^.@\\s%$#/\\|_-]+\\.(com|lt|ru|co.uk)$", "should not contain `%`, `$`, `#`, `|`, `/` and more than one `@`", 256, 15)},
        {PropertyIs.Phone, new("^([\\+]?[0-9]{1,3}[0-9]{1,12})$", "is invalid phone number.", 15, 10)},
        {PropertyIs.DevLang, new("^[a-zA-Z +#.]+$", "should only consist of letters and/or symbols `+`, `#`, `.`", 20, 1)}
    };
}