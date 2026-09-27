using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenshyuuNihongoApi.Enums;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Data.Configurations;

public class MockTestEntityConfiguration : IEntityTypeConfiguration<MockTest>
{
    public void Configure(EntityTypeBuilder<MockTest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Questions)
            .WithOne(x => x.MockTest)
            .HasForeignKey(x => x.MockTestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new MockTest
        {
            Id = SeedData.MockTestId,
            Level = Level.N5,
            CreatedAt = SeedData.Timestamp,
            UpdatedAt = SeedData.Timestamp
        });
    }
}
