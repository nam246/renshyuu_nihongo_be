using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RenshyuuNihongoApi.Data;
using RenshyuuNihongoApi.DTOs;
using RenshyuuNihongoApi.Interfaces;
using RenshyuuNihongoApi.Models;

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

    // Tái sử dụng Expression Mapping cho LINQ Select
    /*
     * Một số linter/style guide (StyleCop, thực hành EF Core phổ biến) khuyến nghị thứ tự: DbSet → AsNoTracking → Where → OrderBy → Select → Skip/Take → Materialize, để chuẩn hóa cách viết trong cả team.
     */
    private static readonly Expression<Func<Vocabulary, VocabularyResponseDto>> MapToDto = v =>
        new VocabularyResponseDto
        {
            Id = v.Id,
            Word = v.Word,
            Kana = v.Kana,
            Romaji = v.Romaji,
            Meaning = v.Meaning,
            WordType = v.WordType,
            Level = v.Level,
            LessonId = v.LessonId,
            CreatedAt = v.CreatedAt,
            UpdatedAt = v.UpdatedAt
        };

    public async Task<VocabularyResponseDto> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var vocabulary = await _context.Vocabularies
            .AsNoTracking()
            .Where(v => v.Id == id)
            .Select(v => new VocabularyResponseDto
            {
                Id = v.Id,
                Word = v.Word,
                Kana = v.Kana,
                Romaji = v.Romaji,
                Meaning = v.Meaning,
                WordType = v.WordType,
                Level = v.Level,
                LessonId = v.LessonId,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (vocabulary == null)
        {
            _logger.LogWarning("Vocabulary with Id {Id} not found", id);
            throw new KeyNotFoundException($"Vocabulary with Id {id} not found");
        }

        _logger.LogInformation("Vocabulary with Id {Id} found", id);

        return vocabulary;
    }

    public async Task<PagedResultDto<VocabularyResponseDto>> FindAllAsync(VocabularyQueryParams queryParams,
        CancellationToken cancellationToken)
    {
        var query = _context.Vocabularies.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            var search = queryParams.SearchTerm.Trim();
            query = query.Where(v
                => v.Word.Contains(search)
                   || v.Kana.Contains(search)
                   || v.Romaji.Contains(search));
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var vocabularies = await query
            .OrderBy(v => v.CreatedAt)
            .ThenBy(v => v.Id)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(v => new VocabularyResponseDto
            {
                Id = v.Id,
                Word = v.Word,
                Kana = v.Kana,
                Romaji = v.Romaji,
                Meaning = v.Meaning,
                WordType = v.WordType,
                Level = v.Level,
                LessonId = v.LessonId,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt
            }).ToListAsync(cancellationToken);

        return new PagedResultDto<VocabularyResponseDto>
        {
            Items = vocabularies,
            TotalCount = totalCount
        };
    }

    public async Task<VocabularyResponseDto> CreateAsync(VocabularyCreateDto dto, CancellationToken cancellationToken)
    {
        var newVocabulary = new Vocabulary
        {
            Word = dto.Word,
            Kana = dto.Kana,
            Romaji = dto.Romaji,
            Meaning = dto.Meaning,
            WordType = dto.WordType,
            Level = dto.Level,
            LessonId = dto.LessonId
        };

        await _context.Vocabularies.AddAsync(newVocabulary, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new VocabularyResponseDto
        {
            Id = newVocabulary.Id,
            Word = newVocabulary.Word,
            Kana = newVocabulary.Kana,
            Romaji = newVocabulary.Romaji,
            Meaning = newVocabulary.Meaning,
            WordType = newVocabulary.WordType,
            Level = newVocabulary.Level,
            LessonId = newVocabulary.LessonId,
            CreatedAt = newVocabulary.CreatedAt,
            UpdatedAt = newVocabulary.UpdatedAt
        };
    }

    public async Task<VocabularyResponseDto> UpdateAsync(Guid id, VocabularyUpdateDto dto,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Vocabularies
                         .FirstOrDefaultAsync(v => v.Id == id, cancellationToken)
                     ?? throw new KeyNotFoundException($"Vocabulary with id '{id}' was not found.");

        // Map only the updatable fields (adjust to your DTO/entity)
        entity.Word = dto.Word;
        entity.Kana = dto.Kana;
        entity.Romaji = dto.Romaji;
        entity.Meaning = dto.Meaning;
        entity.WordType = dto.WordType;
        entity.Level = dto.Level;
        entity.LessonId = dto.LessonId;
        entity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return new VocabularyResponseDto
        {
            Id = entity.Id,
            Word = entity.Word,
            Kana = entity.Kana,
            Romaji = entity.Romaji,
            Meaning = entity.Meaning,
            WordType = entity.WordType,
            Level = entity.Level,
            LessonId = entity.LessonId,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var rowsAffected = await _context.Vocabularies
            .Where(v => v.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        return rowsAffected > 0;
    }
}