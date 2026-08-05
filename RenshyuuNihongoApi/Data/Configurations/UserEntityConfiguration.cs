using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenshyuuNihongoApi.Models;

namespace RenshyuuNihongoApi.Data.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(x => x.Email).HasColumnName("email").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Username).HasColumnName("username").IsRequired();
        builder.Property(x => x.Password).HasColumnName("password").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();

        builder.HasIndex(x => x.Email).IsUnique();
    }
}