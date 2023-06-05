using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Databases.Entities.BookingEntities;

public class Payment
{
    [Key]
    public int Id { get; set; }
    public virtual Product Product { get; set; }
    public virtual Resident Resident { get; set; }
    public string PaymentStatus { get; set; }
    public string TransactionToken { get; set; }
}