using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Databases.Entities.BookingEntities;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<int> RoomsTypes { get; set; }
    public IEnumerable<int> AdditionalFeatures { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    
    [Column(TypeName = "decimal(6,2)")]
    public decimal BasePrice { get; set; }
    public string ThumbnailImage { get; set; }
    public IEnumerable<Image> Images { get; set; } = new List<Image>();
}