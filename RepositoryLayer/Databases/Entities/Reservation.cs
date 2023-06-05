using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Databases.Entities.BookingEntities;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    public virtual IEnumerable<Room> Rooms { get; set; } = new List<Room>();
    public IEnumerable<int> AdditionalFeatures { get; set; }
    public virtual Resident Resident { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}