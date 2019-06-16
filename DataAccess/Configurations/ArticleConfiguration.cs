using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Price).HasMaxLength(5).IsRequired();
            builder.HasMany(p => p.OrderArticles)
                .WithOne(p => p.Article)
                .HasForeignKey(p => p.IdArticle);
        }
    }
}
