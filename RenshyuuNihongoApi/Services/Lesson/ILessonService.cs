using RenshyuuNihongoApi.DTOs;
using RenshyuuNihongoApi.DTOs.Lesson;

namespace RenshyuuNihongoApi.Services.Lesson;

public interface ILessonService
{
    Task<PagedResultDto<LessonResponseDto>> FindAllAsync(QueryParams queryParams, CancellationToken cancellationToken);
    Task<LessonResponseDto> FindByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<LessonCreateDto> CreateAsync(LessonCreateDto dto, CancellationToken cancellationToken);
    Task<LessonUpdateDto> UpdateAsync(LessonUpdateDto dto, Guid id, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}