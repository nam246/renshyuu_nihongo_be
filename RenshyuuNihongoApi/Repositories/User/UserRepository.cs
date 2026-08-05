using Microsoft.EntityFrameworkCore;
using RenshyuuNihongoApi.Data;
using RenshyuuNihongoApi.Interfaces;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) => _context = context;

    public async Task<User?> GetByEmail(string email)
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}