namespace BusinessLayer.DTOs;

public class AdditionalInformationDTO
{
    /// <summary>
    /// Inner exception message.
    /// </summary>
    /// <example>Optional details of error.</example>
    public string? InnerMessage { get; set; }

    /// <summary>
    /// File in witch exception was triggered.
    /// </summary>
    /// <example>C:\\Project\\API\\Controllers\\SomeController.cs</example>
    public string? File { get; set; }

    /// <summary>
    /// Http status code
    /// </summary>
    /// <example>API.Controllers.SomeController GetSomething d__2</example>
    public string? MethodName { get; set; }

    /// <summary>
    /// Line in witch exception was triggered.
    /// </summary>
    /// <example>26</example>
    public int Line { get; set; }

    /// <summary>
    /// Column in witch exception was triggered.
    /// </summary>
    /// <example>9</example>
    public int Column { get; set; }
}