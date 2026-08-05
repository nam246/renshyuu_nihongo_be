using RenshyuuNihongoApi.DTOs;

namespace RenshyuuNihongoApi.Interfaces;
public interface IVocabularyService
{
    Task<VocabularyResponseDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<PagedResultDto<VocabularyResponseDto>> GetPagedAsync(CancellationToken cancellationToken);
    Task<VocabularyCreateDto> CreateAsync(VocabularyCreateDto dto, CancellationToken cancellationToken);
    Task UpdateAsync(Guid Id, CancellationToken cancellationToken);
    Task DeleteAsync(Guid Id, CancellationToken cancellationToken);
}