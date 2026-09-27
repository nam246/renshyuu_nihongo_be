using Microsoft.AspNetCore.Mvc;
using RenshyuuNihongoApi.DTOs;
using RenshyuuNihongoApi.Interfaces;

namespace RenshyuuNihongoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VocabularyController : ControllerBase
{
    private readonly IVocabularyService _service;
    private readonly ILogger<VocabularyController> _logger;

    public VocabularyController(IVocabularyService service, ILogger<VocabularyController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        Console.WriteLine("access from vocabulary/id");
        _logger.LogDebug("message from id");
        return Ok(await _service.FindByIdAsync(id, cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> GetPaged([FromQuery] VocabularyQueryParams queryParams,
        CancellationToken cancellationToken)
    {
        return Ok(await _service.FindAllAsync(queryParams, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VocabularyCreateDto dto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await _service.CreateAsync(dto, cancellationToken);
            return Ok(await _service.CreateAsync(dto, cancellationToken));
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message }); // 409
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] VocabularyUpdateDto dto,
        CancellationToken cancellationToken)
    {
        return Ok(await _service.UpdateAsync(id, dto, cancellationToken));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _service.DeleteAsync(id, cancellationToken));
    }
}