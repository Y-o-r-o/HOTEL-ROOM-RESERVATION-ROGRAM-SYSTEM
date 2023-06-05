namespace BusinessLayer.Configuration;

internal class PropertyValidationConfiguration
{
    public readonly string ValidationRegex;
    public readonly string RegexErrorMessage;
    public readonly int MinimumNameLength;
    public readonly int MaximumNameLength;
    public string LengthErrorMessage => $"length should be between {MinimumNameLength} and {MaximumNameLength}.";

    public PropertyValidationConfiguration(string validationRegex, string regexErrorMessage, int maximumNameLength, int minimumNameLength)
    {
        ValidationRegex = validationRegex;
        RegexErrorMessage = regexErrorMessage;
        MaximumNameLength = maximumNameLength;
        MinimumNameLength = minimumNameLength;
    }
}