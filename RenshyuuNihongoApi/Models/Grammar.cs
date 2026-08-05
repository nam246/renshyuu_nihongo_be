using System.ComponentModel.DataAnnotations;
using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.Models;

public class Grammar
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Pattern { get; set; } = null!;
    public string Structure { get; set; } = null!;
    public string Meaning { get; set; } = null!;
    public string? Explanation { get; set; }
    public string? Notes { get; set; }
    public Level Level { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;

    public ICollection<Example> Examples { get; set; } = new List<Example>();
}