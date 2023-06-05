using BusinessLayer.Enums;

namespace BusinessLayer.DTOs.BookingDTOs;

public class CreateProductDTO
{
    /// <summary>
    /// Name of product.
    /// </summary>
    /// <example>Stay for two.</example>
    public string Name { get; set; }

    /// <summary>
    /// Product have rooms:
    /// </summary>
    /// <example>[ 0 ]</example>
    public IEnumerable<RoomType> RoomsTypes { get; set; } = new List<RoomType>();

    /// <summary>
    /// Product additional features
    /// </summary>
    /// <example>[ 0 ]</example>
    public ISet<AdditionalFeature> AdditionalFeatures { get; set; } = new HashSet<AdditionalFeature>();

    /// <summary>
    /// Product short description
    /// </summary>
    /// <example>Product for couple.</example>
    public string ShortDescription { get; set; }

    /// <summary>
    /// Product description
    /// </summary>
    /// <example>Room for two with pool.</example>
    public string Description { get; set; }

    /// <summary>
    /// Product base price
    /// </summary>
    /// <example>30</example>
    public decimal BasePrice { get; set; }

    /// <summary>
    /// Product thumbnail image url
    /// </summary>
    /// <example>https://imgages.com/imgthumb.png</example>
    public string ThumbnailImage { get; set; }

    /// <summary>
    /// Product images urls
    /// </summary>
    /// <example>[ "https://imgages.com/img.png" ]</example>
    public IEnumerable<string> Images { get; set; } = new List<string>();
}