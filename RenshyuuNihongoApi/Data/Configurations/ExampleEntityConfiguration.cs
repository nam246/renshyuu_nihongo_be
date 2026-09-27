using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Data.Configurations;

public class ExampleEntityConfiguration : IEntityTypeConfiguration<Example>
{
    public void Configure(EntityTypeBuilder<Example> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Vocabulary).WithMany(x => x.Examples).HasForeignKey(x => x.VocabularyId);
        builder.HasOne(x => x.Grammar).WithMany(x => x.Examples).HasForeignKey(x => x.GrammarId);
        builder.HasOne(x => x.Kanji).WithMany(x => x.Examples).HasForeignKey(x => x.KanjiId);

        builder.HasData(new Example
        {
            Id = SeedData.ExampleId,
            Title = "これは私です。",
            Description = "Đây là tôi.",
            VocabularyId = SeedData.VocabularyId,
            GrammarId = SeedData.GrammarId,
            KanjiId = SeedData.KanjiId,
            CreatedAt = SeedData.Timestamp,
            UpdatedAt = SeedData.Timestamp
        });
    }
}
