using DataAccess.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Article_type> Article_types { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderArticle> OrderArticles { get; set; }
        public DbSet<Restaurant_Sector> Restaurant_Sectors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-6JPQMKR\SQLEXPRESS;Initial Catalog=RestaurantDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderArticleConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantSectorConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());
            modelBuilder.ApplyConfiguration(new WaiterConfiguration());

            modelBuilder.Entity<Article_type>().HasData(new Article_type
            {
                Id=1,
                Name="Coffee"
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Manager"
            });
            modelBuilder.Entity<Restaurant_Sector>().HasData(new Restaurant_Sector
            {
                Id=1,
                Name="Garden"
            });
            modelBuilder.Entity<Article>().HasData(new Article
            {
                Id = 1,
                IdArtical_type = 1,
                Name = "Mocca",
                Price = 150
            });
            modelBuilder.Entity<Table>().HasData(new Table
            {
                Id = 1,
                Name = "Table1-Garden",
                IdRestaurant_sector = 1
            });
            modelBuilder.Entity<Waiter>().HasData(new Waiter
            {
                Id = 1,
                IdRole = 1,
                Email = "matejamilicevic97@gmail.com",
                FirstName = "John",
                LastName = "Stockton",
                Password = "mailman1"
            });
        }
    }
}
