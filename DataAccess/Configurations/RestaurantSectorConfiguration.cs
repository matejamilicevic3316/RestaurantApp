using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class RestaurantSectorConfiguration : IEntityTypeConfiguration<Restaurant_Sector>
    {
        public void Configure(EntityTypeBuilder<Restaurant_Sector> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique(); 
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.HasMany(p => p.Tables)
                .WithOne(p => p.Restaurant_Sector)
                .HasForeignKey(p => p.IdRestaurant_sector);
        }
    }
}
