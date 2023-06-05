using AutoMapper;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Interfaces.BookingServices;
using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices.BookingServices;

public class ProductServices : IProductServices
{
    private readonly IProductRepository _productRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public ProductServices(IProductRepository productRepository, IRoomRepository roomRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateProductAsync(CreateProductDTO product)
    {
        var productEntity = _mapper.Map<Product>(product);

        return await _productRepository.CreateProductAsync(productEntity);
    }

    public async Task<IEnumerable<ClientSideProductDTO>> GetAllAvailableClientSideProductsAsync(DateTime startDate, DateTime endDate, string? promoCode)
    {
        var productsEntities = await _productRepository.GetAllProductsAsync();
        var suitableProductEntities = new List<Product>();

        foreach (var productEntity in productsEntities)
        {
            if (await AreRoomsAvailableForDate(productEntity.RoomsTypes, startDate, endDate))
            {
                suitableProductEntities.Add(productEntity);
            }

            if (promoCode != null)
            {
                //calculate special price
            }
        }
        var mappedProducts = _mapper.Map<IEnumerable<ClientSideProductDTO>>(suitableProductEntities);

        return mappedProducts;
    }

    private async Task<bool> AreRoomsAvailableForDate(IEnumerable<int> roomTypes, DateTime startDate, DateTime endDate)
    {
        var roomsEntities = await _roomRepository.GetRoomsAsync();

        var suitableRoomsEntitiesByTypeAndDate = roomsEntities
            .Where(r => r.Reservations.All(res => res.StartDate >= endDate || res.EndDate <= startDate))
            .Where(r => roomTypes.Any(rt => rt == r.Type));

        var roomTypesCounts = roomTypes.GroupBy(l => l).Select(g => (g.First(), g.Count()));

        return roomTypesCounts.All(g => suitableRoomsEntitiesByTypeAndDate.Count(r => r.Type == g.Item1) >= g.Item2);
    }
}