using RenshyuuNihongoApi.Enums;

namespace RenshyuuNihongoApi.DTOs;

public class QueryParams
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? SearchTerm { get; set; }
}