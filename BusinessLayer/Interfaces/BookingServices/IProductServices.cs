using BusinessLayer.DTOs.BookingDTOs;

namespace BusinessLayer.Interfaces.BookingServices;

public interface IProductServices
{
    public Task<int> CreateProductAsync(CreateProductDTO product); 
    public Task<IEnumerable<ClientSideProductDTO>> GetAllAvailableClientSideProductsAsync(DateTime startDate, DateTime endDate, string? promoCode);
}