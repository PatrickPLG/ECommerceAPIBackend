using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                },
                new Category
                {
                    Id = 2,
                    Name = "Jewelry",
                },
                new Category
                {
                    Id = 3,
                    Name = "Men's Clothing",
                },
                new Category
                {
                    Id = 4,
                    Name = "Women's Clothing",
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                    Price = 109.95m,
                    Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                    CategoryId = 3,
                    ImageUrl = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg",
                    Rating = 3.9,
                    Rating_count = 120
                },
                new Product
                {
                    Id = 2,
                    Title = "Mens Casual Premium Slim Fit T-Shirts",
                    Price = 22.30m,
                    Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, lightweight & soft fabric for breathable and comfortable wearing...",
                    CategoryId = 3,
                    ImageUrl = "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg",
                    Rating = 4.1,
                    Rating_count = 259
                },
                // Add more products here as needed...
                new Product
                {
                    Id = 20,
                    Title = "DANVOUY Women T Shirt Casual Cotton Short",
                    Price = 12.99m,
                    Description = "95% Cotton, 5% Spandex; Features: Casual, Short Sleeve, Letter Print, V-Neck, Fashion Tees. The fabric is soft and has some stretch...",
                    CategoryId = 4,
                    ImageUrl = "https://fakestoreapi.com/img/61pHAEJ4NML._AC_UX679_.jpg",
                    Rating = 3.6,
                    Rating_count = 145
                }
            );
            
        }
    }
}
