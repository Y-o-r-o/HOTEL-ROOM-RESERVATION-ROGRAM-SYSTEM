using BusinessLayer.DTOs;
using BusinessLayer.Mappers;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices;

internal class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> GetUserAsync(string id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return ManualMappers.Map(user);
    }

    public async Task<IEnumerable<UserDTO>> GetUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();
        List<UserDTO> mapped = new();
        foreach (AppUser user in users)
        {
            mapped.Add(ManualMappers.Map(user));
        }
        return mapped;
    }
}