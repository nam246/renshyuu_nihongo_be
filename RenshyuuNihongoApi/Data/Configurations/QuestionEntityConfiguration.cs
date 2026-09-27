using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenshyuuNihongoApi.Enums;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Data.Configurations;

public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Section).IsRequired();
        builder.Property(x => x.Answers)
            .IsRequired()
            .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                (left, right) => left == null
                    ? right == null
                    : right != null && left.SequenceEqual(right),
                value => value.Aggregate(0, (hash, item) => HashCode.Combine(hash, item.GetHashCode())),
                value => value.ToList()));

        builder.HasData(new
        {
            Id = SeedData.QuestionId,
            Section = Section.Vocabulary,
            Text = "「私」の読み方は何ですか。",
            Answers = new List<string> { "わたし", "あなた", "たべる", "にち" },
            CorrectAnswer = "わたし",
            MockTestId = (Guid?)SeedData.MockTestId,
            CreatedAt = SeedData.Timestamp,
            UpdatedAt = SeedData.Timestamp
        });
    }
}
