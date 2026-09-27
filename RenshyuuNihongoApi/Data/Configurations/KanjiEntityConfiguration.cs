using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenshyuuNihongoApi.Enums;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Data.Configurations;

public class KanjiEntityConfiguration : IEntityTypeConfiguration<Kanji>
{
    public void Configure(EntityTypeBuilder<Kanji> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Level).IsRequired();
        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.Kanjis)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(new Kanji
        {
            Id = SeedData.KanjiId,
            Character = "日",
            Kana = "ひ",
            Onyomi = "ニチ",
            Kunyomi = "ひ、か",
            Meaning = "Ngày, mặt trời",
            Level = Level.N5,
            StrokeCount = 4,
            LessonId = SeedData.LessonId,
            CreatedAt = SeedData.Timestamp,
            UpdatedAt = SeedData.Timestamp
        });
    }
}
