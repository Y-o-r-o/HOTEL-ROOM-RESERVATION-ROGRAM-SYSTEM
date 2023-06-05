namespace BusinessLayer.DTOs;

public class HttpExceptionDTO
{
    /// <summary>
    /// Http status code
    /// </summary>
    /// <example>500</example>
    public int StatusCode { get; set; }

    /// <summary>
    /// Http error details (dev only)
    /// </summary>
    public AdditionalInformationDTO? Details { get; set; }
}