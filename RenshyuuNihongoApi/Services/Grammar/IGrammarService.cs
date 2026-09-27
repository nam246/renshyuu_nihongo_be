using RenshyuuNihongoApi.DTOs;

namespace RenshyuuNihongoApi.Services.Grammar;

public interface IGrammarService
{
    Task<GrammarResponseDto> FindByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<GrammarResponseDto> CreateAsync(GrammarCreateDto dto, CancellationToken cancellationToken);
    Task<PagedResultDto<GrammarResponseDto>> FindAllAsync(GrammarQueryParams queryParams, CancellationToken cancellationToken);
    Task<GrammarUpdateDto> UpdateAsync(Guid id, GrammarUpdateDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id,  CancellationToken cancellationToken);
}