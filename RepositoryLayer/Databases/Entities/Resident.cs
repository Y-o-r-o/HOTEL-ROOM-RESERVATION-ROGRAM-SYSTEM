using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Databases.Entities.BookingEntities;

public class Resident
{
    [Key]
    public int Id { get; set; }
    public IEnumerable<Reservation>? Reservations { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}