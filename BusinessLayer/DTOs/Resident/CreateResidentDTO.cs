using System.ComponentModel.DataAnnotations;
using BusinessLayer.BusinessServices.Attributes;
using BusinessLayer.Enums;

namespace BusinessLayer.DTOs.BookingDTOs;

public class CreateResidentDTO
{
    /// <summary>
    /// Resident name.
    /// </summary>
    /// <example>Name</example>
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