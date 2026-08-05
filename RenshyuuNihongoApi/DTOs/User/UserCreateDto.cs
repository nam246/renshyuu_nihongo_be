using System.ComponentModel.DataAnnotations;

namespace RenshyuuNihongoApi.DTOs;

public class UserCreateDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Username { get; set; } = string.Empty;

    [Required, MinLength(6)]
    public string Password { get; set; } = string.Empty;
}
