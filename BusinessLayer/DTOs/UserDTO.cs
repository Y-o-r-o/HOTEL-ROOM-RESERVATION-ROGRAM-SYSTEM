namespace BusinessLayer.DTOs;

public class UserDTO
{
    /// <summary>
    /// User ID.
    /// </summary>
    /// <example>2ecb003d-5f09-4f81-82f7-ee7388165432</example>
    public Guid Id { get; set; }

    /// <summary>
    /// User display name.
    /// </summary>
    /// <example>2ecb003d-5f09-4f81-82f7-ee7388165432</example>
    public string DisplayName { get; set; }

    /// <summary>
    /// This user is admin.
    /// </summary>
    /// <example>true</example>
    public bool IsAdmin { get; set; }
}