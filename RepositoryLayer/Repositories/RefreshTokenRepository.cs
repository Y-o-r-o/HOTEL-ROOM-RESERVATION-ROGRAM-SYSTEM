using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;

namespace RepositoryLayer.Repositories;

internal class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly BookingDataContext _dataContext;

    public RefreshTokenRepository(BookingDataContext dataContext) 
    {
        _dataContext = dataContext;
    }

    public async Task<RefreshToken?> GetRefreshTokenByRequestRefreshTokenAsync(string requestRefreshToken)
    {
        return await _dataContext.RefreshTokens
            .SingleOrDefaultAsync(r => r.Token == requestRefreshToken);
    }

    public async Task RemoveRefreshTokenAsync(RefreshToken refreshToken)
    {
        _dataContext.RefreshTokens.Remove(refreshToken);

        await _dataContext.SaveChangesAsync();
    }


    //move part to business layer yo dumb ass!
    //return result!
    public async Task AddRefreshTokenAsync(string refreshToken, string userId)
    {
        _dataContext.RefreshTokens.Add(new RefreshToken() { UserId = userId, Token = refreshToken });

        await _dataContext.SaveChangesAsync();
    }
}