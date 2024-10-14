using Ecommerce.Service.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.Service.ProductAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Photo> Photos{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Appetizer"
            });

            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 1,
                Name = "Nike"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Samosa",
                Price = 15,
                Description = " Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.",
                Image = "https://placehold.co/603x403",
                CategoryId = 1,
                BrandId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = " Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.",
                Image = "https://placehold.co/603x403",
                CategoryId = 1,
                BrandId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Sweet Pie",
                Price = 10.99,
                Description = " Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.",
                Image = "https://placehold.co/603x403",
                CategoryId = 1,
                BrandId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Pav Bhaji",
                Price = 15,
                Description = " Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.",
                Image = "https://placehold.co/603x403",
                CategoryId = 1,
                BrandId = 1
            });
        }
    }
}
