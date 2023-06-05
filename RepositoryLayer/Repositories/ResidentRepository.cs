using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.BookingRepositories;

internal sealed class ResidentRepository : IResidentRepository
{
    private readonly BookingDataContext _dataContext;

    public ResidentRepository(BookingDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> CreateResidentAsync(Resident resident)
    {
        var result = _dataContext.Residents.Add(resident);

        await _dataContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task EditResidentAsync(Resident resident)
    {
        _dataContext.Update(resident);

        await _dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Resident>> GetResidentsAsync(Expression<Func<Resident, bool>>? predicate = null)
    {
        if (predicate == null)
        {
            return await _dataContext.Residents.ToListAsync();
        }

        return await _dataContext.Residents.Where(predicate).ToListAsync();
    }

    public async Task<Resident?> GetResidentByIdAsync(int residentId)
    {
        return await _dataContext.Residents.SingleOrDefaultAsync(p => p.Id == residentId);
    }

    public async Task RemoveResidentAsync(Resident resident)
    {
        _dataContext.Residents.Remove(resident);

        await _dataContext.SaveChangesAsync();
    }

    public async Task RemoveResidentsAsync(IEnumerable<Resident> resident)
    {
        _dataContext.Residents.RemoveRange(resident);

        await _dataContext.SaveChangesAsync();
    }
}