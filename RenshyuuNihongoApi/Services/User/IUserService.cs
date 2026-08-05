using RenshyuuNihongoApi.DTOs;

namespace RenshyuuNihongoApi.Interfaces;

public interface IUserService
{
    Task<UserResponseDto> CreateUserAsync(UserCreateDto dto);
}
