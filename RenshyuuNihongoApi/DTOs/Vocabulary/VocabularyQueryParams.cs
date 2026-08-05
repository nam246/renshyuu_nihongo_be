using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.DTOs;

// DTO cho filter khi lấy danh sách
public class VocabularyQueryParams
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? SearchTerm { get; set; }
    public WordType? WordType { get; set; }
    public Level? Level { get; set; }
    public string? LessonId { get; set; }
}