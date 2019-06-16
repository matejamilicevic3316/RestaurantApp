using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.HasMany(p => p.Orders)
                .WithOne(p => p.Table)
                .HasForeignKey(p => p.IdTable);
        }
    }
}
