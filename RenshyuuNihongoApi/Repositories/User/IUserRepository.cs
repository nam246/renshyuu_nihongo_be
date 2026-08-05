using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmail(string email);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}
