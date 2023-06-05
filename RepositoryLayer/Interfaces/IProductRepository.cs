using System.Linq.Expressions;
using RepositoryLayer.Databases.Entities.BookingEntities;

namespace RepositoryLayer.Interfaces;

public interface IProductRepository
{
    public Task<int> CreateProductAsync(Product product);
    public Task<IEnumerable<Product>> GetAllProductsAsync(Expression<Func<Product, bool>>? predicate = null);
    public Task<Product?> GetProductByIdAsync(int id);

}