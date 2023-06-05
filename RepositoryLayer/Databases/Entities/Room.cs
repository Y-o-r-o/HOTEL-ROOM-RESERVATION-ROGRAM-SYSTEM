using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Databases.Entities.BookingEntities;

public class Room
{
    [Key]
    public int Id { get; set; }
    public int Type { get; set; }
    public string Number { get; set; }
    public virtual IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();
}