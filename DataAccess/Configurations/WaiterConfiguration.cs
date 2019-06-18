using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class WaiterConfiguration : IEntityTypeConfiguration<Waiter>
    {
        public void Configure(EntityTypeBuilder<Waiter> builder)
        {
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(15);
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.Email).IsRequired().HasMaxLength(70);
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.HasMany(p => p.Orders)
                .WithOne(p => p.Waiter)
                .HasForeignKey(p => p.IdWaiter);
        }
    }
}
