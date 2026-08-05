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
        return Ok(await _service.GetByIdAsync(id, cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> GetPaged(CancellationToken cancellationToken)
    {
        Console.WriteLine("access from vocabulary");
        throw new NotImplementedException();
    }

    // [HttpPost]
    // public async Task<ActionResult<VocabularyCreateDto>> Create(VocabularyCreateDto dto)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState);

    //     try
    //     {
    //         var result = await _service.CreateAsync(dto);
    //         return result;
    //     }
    //     catch (InvalidOperationException ex)
    //     {
    //         return Conflict(new { message = ex.Message }); // 409
    //     }
    // }
}