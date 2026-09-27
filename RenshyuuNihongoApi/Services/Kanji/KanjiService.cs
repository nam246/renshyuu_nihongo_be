using Microsoft.EntityFrameworkCore;
using RenshyuuNihongoApi.Data;
using RenshyuuNihongoApi.DTOs;

namespace RenshyuuNihongoApi.Services.Kanji;

public class KanjiService : IKanjiService
{
    private readonly AppDbContext _context;

    public KanjiService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResultDto<KanjiResponseDto>> FindAllAsync(
        QueryParams queryParams,
        CancellationToken cancellationToken)
    {
        var kanjis = await _context.Kanjis
            .AsNoTracking()
            .Select(k => new KanjiResponseDto
            {
                Id = k.Id,
                Character = k.Character,
                Kana   = k.Kana,
                Onyomi = k.Onyomi,
                Kunyomi = k.Kunyomi,
                Meaning = k.Meaning,
                Level = k.Level,
                StrokeCount = k.StrokeCount,
                LessonId = k.LessonId,
                CreatedAt = k.CreatedAt,
                UpdatedAt = k.UpdatedAt,
            })
            .OrderBy(k => k.CreatedAt)
            .ThenBy(v => v.Id)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToListAsync(cancellationToken);
            
        var count = await _context.Kanjis.CountAsync(cancellationToken);

        return new PagedResultDto<KanjiResponseDto>
        {
            Items = kanjis,
            TotalCount = count
        };
    }

    public async Task<KanjiResponseDto> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var kanji = await _context.Kanjis
            .AsNoTracking()
            .Where(k => k.Id == id)
            .Select(k => new KanjiResponseDto
            {
                Id = k.Id,
                Character = k.Character,
                Kana = k.Kana,
                Onyomi = k.Onyomi,
                Kunyomi = k.Kunyomi,
                Meaning = k.Meaning,
                Level = k.Level,
                StrokeCount = k.StrokeCount,
                LessonId = k.LessonId,
                CreatedAt = k.CreatedAt,
                UpdatedAt = k.UpdatedAt,
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (kanji == null)
        {
            throw new KeyNotFoundException($"Kanji with id {id} not found");
        }

        return kanji;
    }

    public async Task<KanjiResponseDto> CreateAsync(
        KanjiCreateDto dto,
        CancellationToken cancellationToken)
    {
        var kanji = new Models.Kanji
        {
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Kanjis.Add(kanji);
        await _context.SaveChangesAsync(cancellationToken);

        return new KanjiResponseDto();
    }

    public async Task<KanjiResponseDto> UpdateAsync(
        Guid id,
        KanjiUpdateDto dto,
        CancellationToken cancellationToken)
    {
        var kanji = await _context.Kanjis.FindAsync([id], cancellationToken);
        if (kanji is null)
        {
            throw new KeyNotFoundException($"Kanji with id {id} not found");
        }

        kanji.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);

        return new KanjiResponseDto();
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var kanji = await _context.Kanjis.FindAsync([id], cancellationToken);
        if (kanji is null)
        {
            return false;
        }

        _context.Kanjis.Remove(kanji);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}