using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ArticleTypeConfiguration : IEntityTypeConfiguration<Article_type>
    {
        public void Configure(EntityTypeBuilder<Article_type> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique(); 
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Articles)
                .WithOne(p => p.Artical_Type)
                .HasForeignKey(p => p.IdArtical_type);
        }
    }
}
