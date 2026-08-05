using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.DTOs;

public class VocabularyResponseDto
{
    public Guid Id { get; set; }
    public string Word { get; set; } = string.Empty;
    public string Kana { get; set; } = string.Empty;
    public string Romaji { get; set; } = string.Empty;
    public string Meaning { get; set; } = string.Empty;
    public WordType WordType { get; set; }
    public Level Level { get; set; }
    public string? LessonId {get; set;}
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}