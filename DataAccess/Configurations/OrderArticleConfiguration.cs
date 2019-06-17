using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class OrderArticleConfiguration : IEntityTypeConfiguration<OrderArticle>
    {
        public void Configure(EntityTypeBuilder<OrderArticle> builder)
        {
            builder.HasKey(p => new { p.IdArticle,p.IdOrder });
        }
    }
}
