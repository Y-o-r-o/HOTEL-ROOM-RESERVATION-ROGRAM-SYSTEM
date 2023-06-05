using System.ComponentModel.DataAnnotations;
using BusinessLayer.BusinessServices.Attributes;
using BusinessLayer.Enums;

namespace BusinessLayer.DTOs.BookingDTOs;

public class ResidentDTO
{
    /// <summary>
    /// Resident Id.
    /// </summary>
    /// <example>1</example>
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Resident name.
    /// </summary>
    /// <example>MyName</example>
    [Required]
    [Validate(propertyIs = PropertyIs.HumanName, modelName = "Resident", propertyName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Resident surname.
    /// </summary>
    /// <example>Surname</example>
    [Required]
    [Validate(propertyIs = PropertyIs.HumanName, modelName = "Resident", propertyName = "Surname")]
    public string Surname { get; set; }

    /// <summary>
    /// Resident email.
    /// </summary>
    /// <example>residentas.vienas@mail.com</example>
    [Required]
    [Validate(propertyIs = PropertyIs.Email, modelName = "Resident", propertyName = "Email")]
    public string Email { get; set; }

    /// <summary>
    /// Resident phone number.
    /// </summary>
    /// <example>+37062347298</example>
    [Required]
    [Validate(propertyIs = PropertyIs.Phone, modelName = "Resident", propertyName = "PhoneNumber")]
    public string PhoneNumber { get; set; }
}