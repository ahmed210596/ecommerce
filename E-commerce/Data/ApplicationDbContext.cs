using E_commerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Emit;

namespace E_commerce.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>  
    {
        


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
           

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductSize>()
             .HasKey(p => new { p.ProductId, p.SizeId });

            modelBuilder.Entity<ProductSize>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.productSizes)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductSize>()
                .HasOne(ps => ps.Size)
                .WithMany(p => p.productSizes)
                .HasForeignKey(p => p.SizeId);
        }

        public DbSet<ApplicationUser> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Size> sizes { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
