using Microsoft.EntityFrameworkCore;
using RenshyuuNihongoApi.Data;
using RenshyuuNihongoApi.DTOs;
using RenshyuuNihongoApi.DTOs.Lesson;

namespace RenshyuuNihongoApi.Services.Lesson;

public class LessonService : ILessonService
{
    private readonly ILogger<LessonService> _logger;
    private readonly AppDbContext _context;

    public LessonService(AppDbContext context, ILogger<LessonService> logger)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<PagedResultDto<LessonResponseDto>> FindAllAsync(QueryParams queryParams,
        CancellationToken cancellationToken)
    {
        var lessons = await _context.Lessons
            .AsNoTracking()
            .Include(x => x.Kanjis)
            .Include(x => x.Grammars)
            .Include(x => x.Vocabularies)
            .Select(x => new LessonResponseDto
            {
                Id = x.Id,
                Vocabularies = x.Vocabularies,
                Kanjis = x.Kanjis,
                Grammars = x.Grammars,
            })
            .ToListAsync(cancellationToken);

        var totalCount =  await _context.Lessons.CountAsync(cancellationToken);

        return new PagedResultDto<LessonResponseDto>
        {
            Items = lessons,
            TotalCount = totalCount,
        };
    }

    public Task<LessonResponseDto> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<LessonCreateDto> CreateAsync(LessonCreateDto lessonCreateDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<LessonUpdateDto> UpdateAsync(LessonUpdateDto lessonUpdateDto, Guid id,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}