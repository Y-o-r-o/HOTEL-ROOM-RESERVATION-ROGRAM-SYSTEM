using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.RegularExpressions;
using BusinessLayer.Configuration;
using BusinessLayer.Enums;
using BusinessLayer.Helpers;
using Core;

namespace BusinessLayer.BusinessServices.Attributes;

internal class Validate : ValidationAttribute
{
    public PropertyIs propertyIs = PropertyIs.Default;
    public string propertyName = "Property";
    public string modelName = "Model";

    protected override ValidationResult? IsValid(object? property, ValidationContext validationContext)
    {
        if (property == null)
        {
            throw new HttpResponseException(HttpStatusCode.InternalServerError, $"Couldnt get attributed property.");
        }

        string? name = property.ToString();

        if (name == null)
        {
            throw new HttpResponseException(HttpStatusCode.InternalServerError, $"Couldnt convert attributed property to string.");
        }

        var errors = new List<string>();

        if (!Constants.PROPERTY_VALIDATIONS.TryGetValue(propertyIs, out PropertyValidationConfiguration? validationParameters))
        {
            throw new HttpResponseException(HttpStatusCode.InternalServerError, $"There is no property validation parameters for enum: {propertyIs}.");
        };

        if (name.Length < validationParameters.MinimumNameLength || name.Length > validationParameters.MaximumNameLength)
        {
            errors.Add($"{modelName}'s property `{propertyName}` {validationParameters.LengthErrorMessage}");
        }

        if (!Regex.IsMatch(name, validationParameters.ValidationRegex))
        {
            errors.Add($"{modelName}'s property `{propertyName}` {validationParameters.RegexErrorMessage}");
        }

        Core.ValidationException.ThrowIfPropertyInvalid(propertyName, errors);

        return ValidationResult.Success;
    }
}