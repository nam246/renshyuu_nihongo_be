using System.ComponentModel.DataAnnotations;

namespace RenshyuuNihongoApi.Models;

public class Example
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Guid VocabularyId { get; set; }
    public Vocabulary Vocabulary { get; set; } = null!;

    public Guid GrammarId { get; set; }
    public Grammar Grammar { get; set; } = null!;

    public Guid KanjiId { get; set; }
    public Kanji Kanji { get; set; } = null!;
}