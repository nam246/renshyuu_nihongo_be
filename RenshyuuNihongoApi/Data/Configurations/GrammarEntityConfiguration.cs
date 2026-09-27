using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenshyuuNihongoApi.Enums;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Data.Configurations;

public class GrammarEntityConfiguration : IEntityTypeConfiguration<Grammar>
{
    public void Configure(EntityTypeBuilder<Grammar> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Level).IsRequired();
        builder.Property(x => x.Notes)
            .Metadata.SetValueComparer(new ValueComparer<List<string>?>(
                (left, right) => left != null && right != null
                    ? left.SequenceEqual(right)
                    : left == right,
                value => value == null
                    ? 0
                    : value.Aggregate(0, (hash, item) => HashCode.Combine(hash, item.GetHashCode())),
                value => value == null ? null : value.ToList()));
        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.Grammars)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(new Grammar
        {
            Id = SeedData.GrammarId,
            Pattern = "〜です",
            Structure = "N は N です",
            Meaning = "Là...",
            Explanation = "Dùng để giới thiệu hoặc mô tả danh tính, trạng thái.",
            Notes = new List<string> { "Danh từ đứng trước は là chủ đề." },
            Level = Level.N5,
            LessonId = SeedData.LessonId,
            CreatedAt = SeedData.Timestamp,
            UpdatedAt = SeedData.Timestamp
        });
    }
}
