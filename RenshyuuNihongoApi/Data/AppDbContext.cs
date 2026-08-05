using Microsoft.EntityFrameworkCore;
using RenshyuuNihongoApi.Models;
using RenshyuuNihongoApi.Data.Configurations;

namespace RenshyuuNihongoApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
 
    public DbSet<User> Users { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Vocabulary> Vocabularies { get; set; }
    public DbSet<Grammar> Grammars { get; set; }
    public DbSet<Kanji> Kanjis { get; set; }
    // public DbSet<VocabularyKanji> VocabularyKanjis { get; set; }
    // public DbSet<Listening> Listenings { get; set; }
    // public DbSet<Reading> Readings { get; set; }
    // public DbSet<Media> Medias { get; set; }
    public DbSet<Example> Examples { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new LessonEntityConfiguration());
        modelBuilder.ApplyConfiguration(new VocabularyEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new GrammarEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new KanjiEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new VocabularyKanjiEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new ListeningEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new ReadingEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new MediaEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new ExampleEntityConfiguration());
 
        base.OnModelCreating(modelBuilder);
    }
}