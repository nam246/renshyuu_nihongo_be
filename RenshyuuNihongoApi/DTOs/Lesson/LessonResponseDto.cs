using System.Data;
using RenshyuuNihongoApi.Models;
using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.DTOs;

public class LessonResponseDto
{
    public Guid Id { get; set; }
    public int LessonNumber { get; set; }
    public Level Level { get; set; }
    public string? Source { get; set; }
    public ICollection<Vocabulary> Vocabularies { get; set; } = new List<Vocabulary>();
    public ICollection<Grammar> Grammars { get; set; } = new List<Grammar>();
    public ICollection<Kanji> Kanjis { get; set; } = new List<Kanji>();
}