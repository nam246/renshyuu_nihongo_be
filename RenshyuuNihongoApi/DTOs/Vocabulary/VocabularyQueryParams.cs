using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.DTOs;

// DTO cho filter khi lấy danh sách
public class VocabularyQueryParams : QueryParams
{
    public WordType? WordType { get; set; }
    public Level? Level { get; set; }
    public string? LessonId { get; set; }
}