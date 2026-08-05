using BCrypt.Net;
using RenshyuuNihongoApi.DTOs;
using RenshyuuNihongoApi.Interfaces;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo) => _repo = repo;

    public async Task<UserResponseDto> CreateUserAsync(UserCreateDto dto)
    {
        // Business rule 1: check email đã tồn tại chưa
        var existing = await _repo.GetByEmail(dto.Email);
        if (existing != null)
            throw new InvalidOperationException("Email đã được sử dụng");

        // Business rule 2: hash password trước khi lưu
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Email = dto.Email,
            Username = dto.Username,
            Password = hashedPassword
        };

        await _repo.AddAsync(user);
        await _repo.SaveChangesAsync();

        // Map Entity -> Response DTO (không trả PasswordHash)
        return new UserResponseDto
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username,
            CreatedAt = user.CreatedAt
        };
    }
}