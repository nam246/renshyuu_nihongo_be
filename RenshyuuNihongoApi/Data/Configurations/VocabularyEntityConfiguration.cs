using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenshyuuNihongoApi.Models;
using RenshyuuNihongoApi.Enums;
namespace RenshyuuNihongoApi.Data.Configurations;

public class VocabularyEntityConfiguration : IEntityTypeConfiguration<Vocabulary>
{
    public void Configure(EntityTypeBuilder<Vocabulary> entity)
    {
        /*
         * Loai bo .HasColumnName() vì o Program.cs đã có options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention()
         */
        
        entity.HasKey(v => v.Id);
        
        entity.Property(v => v.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired();
            
        entity.Property(v => v.Word)
            .HasMaxLength(255)
            .IsRequired();
        
        entity.Property(v => v.Kana)
            .HasMaxLength(255)
            .IsRequired();
            
        entity.Property(v => v.Romaji)
            .HasMaxLength(255)
            .IsRequired();
            
        entity.Property(v => v.Meaning)
            .IsRequired();
            
        entity.Property(v => v.WordType)
            .HasConversion<string>()
            .IsRequired();
            
        entity.Property(v => v.Level)
            .HasConversion<string>()
            .IsRequired();
            
        entity.Property(v => v.LessonId)
          ;
            
        entity.Property(v => v.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
            
        entity.Property(v => v.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate()
            .IsRequired();
        
        entity.HasIndex(v => v.LessonId)
            .HasDatabaseName("IX_vocabulary_lesson_id");
        
        // Relationships
        entity.HasOne(v => v.Lesson)
            .WithMany(l => l.Vocabularies)
            .HasForeignKey(v => v.LessonId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_vocabulary_lesson_id");
        
        entity.HasMany(v => v.Examples)
            .WithOne(e => e.Vocabulary)
            .HasForeignKey(e => e.VocabularyId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seed data
        var lessonId = SeedData.LessonId;
        entity.HasData(
            new Vocabulary
            {
                Id = SeedData.VocabularyId,
                Word = "私",
                Kana = "わたし",
                Romaji = "watashi",
                Meaning = "Tôi",
                WordType = WordType.PRONOUN,
                Level = Level.N5,
                LessonId = lessonId,
                CreatedAt = SeedData.Timestamp,
                UpdatedAt = SeedData.Timestamp
            },
            new Vocabulary
            {
                Id = SeedData.VocabularyId2,
                Word = "あなた",
                Kana = "あなた",
                Romaji = "anata",
                Meaning = "Bạn",
                WordType = WordType.PRONOUN,
                Level = Level.N5,
                LessonId = lessonId,
                CreatedAt = SeedData.Timestamp,
                UpdatedAt = SeedData.Timestamp
            },
            new Vocabulary
            {
                Id = SeedData.VocabularyId3,
                Word = "食べる",
                Kana = "たべる",
                Romaji = "taberu",
                Meaning = "Ăn",
                WordType = WordType.VERB,
                Level = Level.N5,
                LessonId = lessonId,
                CreatedAt = SeedData.Timestamp,
                UpdatedAt = SeedData.Timestamp
            }
        );
    }
}