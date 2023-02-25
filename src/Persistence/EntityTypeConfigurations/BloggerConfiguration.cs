using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations;

public class BloggerConfiguration : IEntityTypeConfiguration<Blogger>
{
    public void Configure(EntityTypeBuilder<Blogger> builder)
    {
        builder.ToTable("blogger");

        builder.HasKey(x => x.Id).HasName("первичный ключь");

        #region Indexes
        
        builder.HasIndex(x => x.Id, "pk_blogger_id").IsUnique();
        
        #endregion

        #region Properties
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasComment("первичный ключь")
            .IsRequired();
        builder.Property(x => x.Nickname)
            .HasColumnName("nickname")
            .HasComment("ник блоггера")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.FirstName)
            .HasColumnName("firstname")
            .HasComment("имя")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.LastName)
            .HasColumnName("lastname")
            .HasComment("фамилия")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.Created)
            .HasColumnName("created")
            .HasComment("дата и время регистрации")
            .IsRequired();
        #endregion

        #region Relations
        
        builder.HasMany(b => b.Posts)
            .WithOne(p => p.Blogger)
            .HasForeignKey(p => p.BloggerId);

        #endregion
    }
}