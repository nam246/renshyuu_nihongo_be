namespace RenshyuuNihongoApi.Services.Bookmark;

public interface IBookmarkService
{
    Task CreateAsync(CancellationToken cancellationToken);
    Task ToggleAsync(CancellationToken cancellationToken);
    Task FindByUserIdAsync(Guid id, CancellationToken cancellationToken);
    Task FindBookmarkedVocabularyAsync(Guid id, CancellationToken cancellationToken);
    Task FindBookmarkedGrammarAsync(Guid id, CancellationToken cancellationToken);
    Task FindBookmarkedKanjiAsync(Guid id, CancellationToken cancellationToken);
}