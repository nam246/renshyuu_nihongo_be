using Microsoft.AspNetCore.Mvc;
using RenshyuuNihongoApi.DTOs;
using RenshyuuNihongoApi.Interfaces;

namespace RenshyuuNihongoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service) => _service = service;

    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> Create(UserCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await _service.CreateUserAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message }); // 409
        }
    }
}