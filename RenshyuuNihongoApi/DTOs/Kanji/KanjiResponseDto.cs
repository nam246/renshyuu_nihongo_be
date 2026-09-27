using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.DTOs;

public class KanjiResponseDto
{
    public Guid Id { get; set; }
    public string Character { get; set; } = null!;
    public string Kana { get; set; } = null!;
    public string? Onyomi { get; set; }
    public string? Kunyomi { get; set; }
    public string Meaning { get; set; } = null!;
    public Level Level { get; set; }
    public int? StrokeCount { get; set; }
    
    public Guid LessonId { get; set; }
    public Models.Lesson Lesson { get; set; } = null!;
    
    // public ICollection<Example> Examples { get; set; } = new List<Example>();
    // public ICollection<VocabularyKanji> VocabularyKanjis { get; set; } = new List<VocabularyKanji>();
    // public ICollection<Vocabulary> Vocabularies { get; set; } = new List<Vocabulary>();
    public DateTime CreatedAt{ get; set; }
    public DateTime UpdatedAt { get; set; }
}