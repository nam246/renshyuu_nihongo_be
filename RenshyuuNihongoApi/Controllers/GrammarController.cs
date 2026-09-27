using Microsoft.AspNetCore.Mvc;
using RenshyuuNihongoApi.DTOs;
using RenshyuuNihongoApi.Services.Grammar;

namespace RenshyuuNihongoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GrammarController : ControllerBase
{
    private readonly ILogger<GrammarController> _logger;
    private readonly IGrammarService _service;

    public GrammarController(ILogger<GrammarController> logger, GrammarService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> FindAll([FromQuery] GrammarQueryParams queryParams, CancellationToken cancellationToken)
    {
        return Ok(await _service.FindAllAsync(queryParams, cancellationToken));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindOne(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _service.FindByIdAsync(id, cancellationToken));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id, 
        GrammarUpdateDto dto, 
        CancellationToken cancellationToken)
    {
        var result = await _service.UpdateAsync(id, dto, cancellationToken);
    
        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _service.DeleteAsync(id, cancellationToken));
    }
}