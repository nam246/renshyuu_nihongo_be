using RenshyuuNihongoApi.DTOs;

namespace RenshyuuNihongoApi.Interfaces;
public interface IVocabularyService
{
    Task<VocabularyResponseDto> FindByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<VocabularyResponseDto> CreateAsync(VocabularyCreateDto dto, CancellationToken cancellationToken);
    Task<PagedResultDto<VocabularyResponseDto>> FindAllAsync(VocabularyQueryParams queryParams, CancellationToken cancellationToken);
    Task<VocabularyResponseDto> UpdateAsync(Guid id, VocabularyUpdateDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}