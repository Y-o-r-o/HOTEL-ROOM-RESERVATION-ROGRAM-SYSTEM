using RepositoryLayer.Databases.Entities.BookingEntities;
using System.Linq.Expressions;

namespace RepositoryLayer.Interfaces;

public interface IResidentRepository
{
    Task<int> CreateResidentAsync(Resident resident);
    Task EditResidentAsync(Resident resident);
    Task<IEnumerable<Resident>> GetResidentsAsync(Expression<Func<Resident, bool>>? predicate = null);
    Task<Resident?> GetResidentByIdAsync(int residentId);
    Task RemoveResidentAsync(Resident resident);
    Task RemoveResidentsAsync(IEnumerable<Resident> residents);
}