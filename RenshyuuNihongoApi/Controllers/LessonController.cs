using Microsoft.AspNetCore.Mvc;
using RenshyuuNihongoApi.DTOs;
using RenshyuuNihongoApi.DTOs.Lesson;
using RenshyuuNihongoApi.Services.Lesson;

namespace RenshyuuNihongoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase
{
    private readonly ILogger<LessonController> _logger;
    private readonly ILessonService _service;

    public LessonController(ILogger<LessonController> logger, ILessonService service)
    {
        _logger = logger;
        _service = service;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> FindAll([FromQuery] QueryParams queryParams ,CancellationToken cancellationToken)
    {
        _logger.LogInformation("Access FindAll from Lesson Controller");
        return Ok(await _service.FindAllAsync(queryParams, cancellationToken));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Access FindById from Lesson Controller");
        return Ok(await _service.FindByIdAsync(id, cancellationToken));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] LessonCreateDto lessonCreateDto, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Access FindAll from Lesson Controller");
        return Ok(await _service.CreateAsync(lessonCreateDto, cancellationToken));
    }
}