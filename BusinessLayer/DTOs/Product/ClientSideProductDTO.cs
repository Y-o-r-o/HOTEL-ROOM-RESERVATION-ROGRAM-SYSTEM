namespace BusinessLayer.DTOs.BookingDTOs;

public class ClientSideProductDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal? SpecialPrice { get; set; }
    public string ThumbnailImage { get; set; }
    public IEnumerable<string> Images { get; set; } = new List<string>();
}