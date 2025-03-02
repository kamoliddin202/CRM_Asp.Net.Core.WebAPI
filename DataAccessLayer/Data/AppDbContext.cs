using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ContactHistory> ContactHistories { get; set; } // Ixtiyoriy
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.ContactHistories)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);


            modelBuilder.Entity<Product>()
                .HasMany(c => c.Orders)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId);


            modelBuilder.Entity<Order>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<Product>()
                    .HasOne(c => c.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(c => c.CategoryId);

        }

    }
}
