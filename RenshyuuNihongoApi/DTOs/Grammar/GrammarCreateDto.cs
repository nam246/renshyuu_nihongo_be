using System.ComponentModel.DataAnnotations;
using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.DTOs;

public class GrammarCreateDto
{
    [Required(ErrorMessage = "Pattern is required")]
    [MaxLength(200)]
    public string Pattern { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Structure is required")]
    [MaxLength(500)]
    public string Structure { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Meaning is required")]
    [MaxLength(300)]
    public string Meaning { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Explanation { get; set; }
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    [Required(ErrorMessage = "Level is required")]
    public Level Level { get; set; }
    
    [Required(ErrorMessage = "LessonId is required")]
    public Guid LessonId { get; set; }
}

public class ResponseCreateDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
}