using RenshyuuNihongoApi.DTOs;

namespace RenshyuuNihongoApi.Services.Kanji;

public interface IKanjiService
{
    Task<KanjiResponseDto> FindByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<KanjiResponseDto> CreateAsync(KanjiCreateDto dto, CancellationToken cancellationToken);
    Task<PagedResultDto<KanjiResponseDto>> FindAllAsync(QueryParams queryParams, CancellationToken cancellationToken);
    Task<KanjiResponseDto> UpdateAsync(Guid id, KanjiUpdateDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}