using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly BookingDataContext _dataContext;
    protected IQueryable<AppUser> Entities { get; set; }

    public UserRepository(BookingDataContext dataContext, SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
        _dataContext =dataContext;
        Entities = dataContext.Set<AppUser>();
    }

    public async Task<AppUser?> GetUserByIdAsync(string id)
    {
        return await Entities.SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<AppUser?> GetUserByEmailAsync(string email)
    {
        return await Entities.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync(Expression<Func<AppUser, bool>>? predicate = null)
    {
        if (predicate == null)
        {
            return await Entities.ToListAsync();
        }

        return await Entities.Where(predicate).ToListAsync();
    }

    //perkelt i business layer
    public async Task<SignInResult?> SignInUserByPasswordAsync(AppUser user, string password)
    {
        var res = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        await _dataContext.SaveChangesAsync();
        return res;
    }
}