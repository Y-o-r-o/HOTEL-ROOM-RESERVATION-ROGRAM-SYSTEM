namespace BusinessLayer.DTOs;

public class ValidationHttpExceptionDTO : HttpExceptionDTO
{
    public ValidationHttpExceptionDTO(KeyValuePair<string, IEnumerable<string>> propertyErrors, AdditionalInformationDTO? details = null)
    {
        PropertyErrors = propertyErrors;
        Details = details;
        StatusCode = 400;
    }

    /// <summary>
    /// Property error messages.
    /// </summary>
    public KeyValuePair<string, IEnumerable<string>> PropertyErrors { get; set; }
}