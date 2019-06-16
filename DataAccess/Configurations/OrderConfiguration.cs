using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IsStorned).HasDefaultValue(false);
            builder.Property(p => p.IsPaid).HasDefaultValue(false);
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.HasMany(p => p.OrderArticles)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.IdOrder)
                .OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}
