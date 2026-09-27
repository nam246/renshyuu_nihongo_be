using System.ComponentModel.DataAnnotations;
using RenshyuuNihongoApi.Models.Base;

namespace RenshyuuNihongoApi.Models;

public class Example : BaseModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Guid VocabularyId { get; set; }
    public Vocabulary Vocabulary { get; set; } = null!;

    public Guid GrammarId { get; set; }
    public Grammar Grammar { get; set; } = null!;

    public Guid KanjiId { get; set; }
    public Kanji Kanji { get; set; } = null!;
}