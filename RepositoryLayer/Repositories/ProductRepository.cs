using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly BookingDataContext _dataContext;

    public ProductRepository(BookingDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> CreateProductAsync(Product product)
    {
        var result = _dataContext.Products.Add(product);

        await _dataContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(Expression<Func<Product, bool>>? predicate = null)
    {
        if (predicate == null)
        {
            return await _dataContext.Products.ToListAsync();
        }

        return await _dataContext.Products.Where(predicate).ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _dataContext.Products
            .SingleOrDefaultAsync(r => r.Id == id);
    }
}