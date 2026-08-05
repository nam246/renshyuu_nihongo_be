using Microsoft.EntityFrameworkCore;
using RenshyuuNihongoApi.Data;
using RenshyuuNihongoApi.DTOs;
using RenshyuuNihongoApi.Interfaces;

namespace RenshyuuNihongoApi.Services;

public class VocabularyService : IVocabularyService
{
    private readonly AppDbContext _context;
    private readonly ILogger<VocabularyService> _logger;

    public VocabularyService(AppDbContext context, ILogger<VocabularyService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<VocabularyResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var vocabulary = await _context.Vocabularies.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        _logger.LogInformation("vocabulary");
        return new VocabularyResponseDto
        {
            Id = vocabulary.Id,
            Word = vocabulary.Word,
            Kana = vocabulary.Kana,
            Romaji = vocabulary.Romaji,
            Meaning = vocabulary.Meaning,

            WordType = vocabulary.WordType,
            Level = vocabulary.Level,
            // LessonId = vocabulary.LessonId,
            CreatedAt = vocabulary.CreatedAt,
            UpdatedAt = vocabulary.UpdatedAt
        };
    }

    public async Task<PagedResultDto<VocabularyResponseDto>> GetPagedAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug("message from service");
        throw new NotImplementedException();
    }

    public async Task<VocabularyCreateDto> CreateAsync(VocabularyCreateDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}