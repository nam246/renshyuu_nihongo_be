using System.ComponentModel.DataAnnotations;
using RenshyuuNihongoApi.Models.Base;

namespace RenshyuuNihongoApi.Models;

public class User : BaseModel
{
    public string Email { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}