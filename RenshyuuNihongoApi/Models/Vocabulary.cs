using System.ComponentModel.DataAnnotations;
using RenshyuuNihongoApi.Enums;
using RenshyuuNihongoApi.Models.Base;

namespace RenshyuuNihongoApi.Models;

public class Vocabulary : BaseModel
{
    public string Word { get; set; } = string.Empty;
    public string Kana { get; set; } = string.Empty;
    public string Romaji { get; set; } = string.Empty;
    public string Meaning { get; set; } = string.Empty;
    public WordType WordType { get; set; }
    public Level Level { get; set; }

    // Foreign Key
    public Guid? LessonId { get; set; }

    // Navigation Properties
    public Lesson? Lesson { get; set; }
    public ICollection<Example> Examples { get; set; } = new List<Example>();
    // public ICollection<Media> Medias { get; set; } = new List<Media>();
    // public ICollection<VocabularyKanji> VocabularyKanjis { get; set; } = new List<VocabularyKanji>
    public ICollection<Kanji> Kanjis { get; set; } = new List<Kanji>();
}