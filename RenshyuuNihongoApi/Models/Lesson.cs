using System.ComponentModel.DataAnnotations;
using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.Models;

public class Lesson
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int LessonNumber { get; set; }
    public string? Source { get; set; }
    public Level Level { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
 
    public ICollection<Vocabulary> Vocabularies { get; set; } = new List<Vocabulary>();
    public ICollection<Grammar> Grammars { get; set; } = new List<Grammar>();
    public ICollection<Kanji> Kanjis { get; set; } = new List<Kanji>();
}