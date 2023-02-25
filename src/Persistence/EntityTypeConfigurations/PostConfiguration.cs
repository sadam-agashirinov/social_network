using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("post");

        builder.HasKey(x => x.Id).HasName("первичный ключь");

        #region Indexes

        builder.HasIndex(x => x.Id, "pk_post_id").IsUnique();

        #endregion

        #region Properties

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasComment("первичный ключь")
            .IsRequired();
        builder.Property(x => x.Text)
            .HasColumnName("text")
            .HasComment("текст поста")
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(x => x.Created)
            .HasColumnName("created")
            .HasComment("дата и время создания поста")
            .IsRequired();

        #endregion

        #region Relations

        builder.HasOne(p => p.Blogger)
            .WithMany(b => b.Posts)
            .HasForeignKey(p => p.BloggerId);

        #endregion
    }
}