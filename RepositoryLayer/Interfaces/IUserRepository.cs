using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Databases.Entities;

namespace RepositoryLayer.Interfaces;

public interface IUserRepository
{
    public Task<AppUser?> GetUserByIdAsync(string id);

    public Task<AppUser?> GetUserByEmailAsync(string email);

    public Task<IEnumerable<AppUser>> GetUsersAsync(Expression<Func<AppUser, bool>>? predicate = null);

    public Task<SignInResult?> SignInUserByPasswordAsync(AppUser user, string password);
}