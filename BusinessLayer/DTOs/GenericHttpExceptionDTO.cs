namespace BusinessLayer.DTOs;

public class GenericHttpExceptionDTO : HttpExceptionDTO
{
    public GenericHttpExceptionDTO(int statusCode, string message, AdditionalInformationDTO? details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }

    /// <summary>
    /// Http error message
    /// </summary>
    /// <example>Internal server error.</example>
    public string Message { get; set; }
}