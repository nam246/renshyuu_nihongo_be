using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.DTOs;

public class GrammarResponseDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Pattern { get; set; } = null!;
    public string Structure { get; set; } = null!;
    public string Meaning { get; set; } = null!;
    public string? Explanation { get; set; }
    public List<string?> Notes { get; set; } = new();
    public Level Level { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid LessonId { get; set; }
}