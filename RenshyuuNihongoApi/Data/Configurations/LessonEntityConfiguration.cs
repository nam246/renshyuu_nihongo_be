using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Data.Configurations;

public class LessonEntityConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lesson");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(x => x.LessonNumber).HasColumnName("lesson_number").IsRequired();
        builder.Property(x => x.Source).HasColumnName("source");
        builder.Property(x => x.Level).HasColumnName("level").HasConversion<string>().IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();

        builder.HasIndex(x => x.LessonNumber).IsUnique();
        builder.HasIndex(x => x.Level);
        builder.HasIndex(x => x.Source);

        builder.HasMany(x => x.Vocabularies)
            .WithOne(v => v.Lesson)
            .HasForeignKey(v => v.LessonId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Grammars)
            .WithOne(g => g.Lesson)
            .HasForeignKey(g => g.LessonId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Kanjis)
            .WithOne(k => k.Lesson)
            .HasForeignKey(k => k.LessonId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}