namespace RenshyuuNihongoApi.DTOs;

public class PagedResultDto<T>
{
    public List<T> Items {get; set;} = [];
    public int TotalCount {get; set;}
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}