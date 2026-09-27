using RenshyuuNihongoApi.Models;
using RenshyuuNihongoApi.Data;
using RenshyuuNihongoApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace RenshyuuNihongoApi.Services.Grammar;

public class GrammarService : IGrammarService
{
    private readonly AppDbContext _context;
    private readonly ILogger<GrammarService> _logger;

    public GrammarService(AppDbContext context, ILogger<GrammarService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GrammarResponseDto> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var grammar = await _context.Grammars
            .AsNoTracking()
            .Where(g => g.Id == id)
            .Select(g => new GrammarResponseDto
            {
                Id = g.Id,
                Pattern = g.Pattern,
                Structure = g.Structure,
                Meaning = g.Meaning,
                Explanation = g.Explanation.Trim(),
                Notes = g.Notes,
                Level = g.Level,
                LessonId = g.LessonId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            })
            .FirstOrDefaultAsync(cancellationToken);
        
        if (grammar == null)
            throw new KeyNotFoundException($"Grammar with id {id} not found");

        return grammar;
    }

    public async Task<GrammarResponseDto> CreateAsync(GrammarCreateDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var newGrammar = new Models.Grammar
            {
                Id = Guid.NewGuid(),
                Pattern = dto.Pattern.Trim(),
                Structure = dto.Structure.Trim(),
                Meaning = dto.Meaning.Trim(),
                Explanation = dto.Explanation?.Trim(),
                Notes = string.IsNullOrWhiteSpace(dto.Notes) ? null : new List<string> { dto.Notes },
                Level = dto.Level,
                LessonId = dto.LessonId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Examples = new List<Example>() // Khởi tạo empty list
            };

            await _context.Grammars.AddAsync(newGrammar, cancellationToken);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return new GrammarResponseDto
            {
                Id = newGrammar.Id,
                Pattern = newGrammar.Pattern,
                Structure = newGrammar.Structure,
                Meaning = newGrammar.Meaning,
                Explanation = newGrammar.Explanation,
                Notes = newGrammar.Notes?.Cast<string?>().ToList() ?? new List<string?>(),
                Level = newGrammar.Level,
                LessonId = newGrammar.LessonId,
                CreatedAt = newGrammar.CreatedAt,
                UpdatedAt = newGrammar.UpdatedAt
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<PagedResultDto<GrammarResponseDto>> FindAllAsync(GrammarQueryParams queryParams,
        CancellationToken cancellationToken)
    {
        var grammars = await _context.Grammars
            .AsNoTracking()
            .Select(g => new GrammarResponseDto
            {
                Id = g.Id,
                Pattern = g.Pattern,
                Structure = g.Structure,
                Meaning = g.Meaning,
                Explanation = g.Explanation,
                Notes = g.Notes.Cast<string?>().ToList() ?? new List<string?>(),
                Level = g.Level,
                LessonId = g.LessonId,
                CreatedAt = g.CreatedAt,
                UpdatedAt = g.UpdatedAt
            })
            .ToListAsync(cancellationToken);

        return new PagedResultDto<GrammarResponseDto>
        {
            Items = grammars,
            TotalCount = grammars.Count
        };
    }

    public async Task<GrammarUpdateDto> UpdateAsync(Guid id, GrammarUpdateDto dto, CancellationToken cancellationToken)
    {
        var grammar = await _context.Grammars.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        if (grammar == null)
            throw new KeyNotFoundException($"Grammar with id {dto.Id} not found");

        grammar.Pattern = dto.Pattern?.Trim() ?? grammar.Pattern;
        grammar.Structure = dto.Structure?.Trim() ?? grammar.Structure;
        grammar.Meaning = dto.Meaning?.Trim() ?? grammar.Meaning;
        grammar.Explanation = dto.Explanation?.Trim();
        grammar.Notes = dto.Notes?.Cast<string>().ToList();
        grammar.Level = dto.Level;
        grammar.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return dto;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var rowAffected = await _context.Grammars.Where(g => g.Id == id).ExecuteDeleteAsync(cancellationToken);

        return rowAffected > 0;
    }
}