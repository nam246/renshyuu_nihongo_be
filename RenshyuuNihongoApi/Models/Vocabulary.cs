using System.ComponentModel.DataAnnotations;
using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.Models;

public class Vocabulary
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Word { get; set; } = string.Empty;
    public string Kana { get; set; } = string.Empty;
    public string Romaji { get; set; } = string.Empty;
    public string Meaning { get; set; } = string.Empty;
    public WordType WordType { get; set; }
    public Level Level { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Key
    public Guid LessonId { get; set; }

    // Navigation Properties
    public Lesson Lesson { get; set; } = null!;
    public ICollection<Example> Examples { get; set; } = new List<Example>();
    // public ICollection<Media> Medias { get; set; } = new List<Media>();
    // public ICollection<VocabularyKanji> VocabularyKanjis { get; set; } = new List<VocabularyKanji>
    public ICollection<Kanji> Kanjis { get; set; } = new List<Kanji>();
}