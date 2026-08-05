using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Data.Configurations;

public class VocabularyEntityConfiguration : IEntityTypeConfiguration<Vocabulary>
{
    public void Configure(EntityTypeBuilder<Vocabulary> entity)
    {
        entity.ToTable("vocabulary");
        
        entity.HasKey(v => v.Id);
        
        entity.Property(v => v.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired();
            
        entity.Property(v => v.Word)
            .HasColumnName("word")
            .HasMaxLength(255)
            .IsRequired();
        
        entity.Property(v => v.Kana)
            .HasColumnName("kana")
            .HasMaxLength(255)
            .IsRequired();
            
        entity.Property(v => v.Romaji)
            .HasColumnName("romaji")
            .HasMaxLength(255)
            .IsRequired();
            
        entity.Property(v => v.Meaning)
            .HasColumnName("meaning")
            .IsRequired();
            
        entity.Property(v => v.WordType)
            .HasColumnName("word_type")
            .HasConversion<string>()
            .IsRequired();
            
        entity.Property(v => v.Level)
            .HasColumnName("level")
            .HasConversion<string>()
            .IsRequired();
            
        entity.Property(v => v.LessonId)
            .HasColumnName("lesson_id");
            
        entity.Property(v => v.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
            
        entity.Property(v => v.UpdatedAt)
            .HasColumnName("updated_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate()
            .IsRequired();
        
        entity.HasIndex(v => v.LessonId)
            .HasDatabaseName("IX_vocabulary_lesson_id");
        
        // Relationships
        entity.HasOne(v => v.Lesson)
            .WithMany(l => l.Vocabularies)
            .HasForeignKey(v => v.LessonId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_vocabulary_lesson_id");
        
        entity.HasMany(v => v.Examples)
            .WithOne(e => e.Vocabulary)
            .HasForeignKey(e => e.VocabularyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}