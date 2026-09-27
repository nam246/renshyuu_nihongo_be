using System.ComponentModel.DataAnnotations;
using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.DTOs;

public class GrammarUpdateDto
{
    [Required]
    public Guid Id { get; set; }
    public string Pattern { get; set; } = null!;
    public string Structure { get; set; } = null!;
    public string Meaning { get; set; } = null!;
    public string? Explanation { get; set; }
    public List<string?> Notes { get; set; } = new();
    public Level Level { get; set; }
    public Guid LessonId { get; set; }
}