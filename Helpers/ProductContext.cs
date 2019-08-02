using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TrySimpleApi.Domain.Product.Entities;

namespace TrySimpleApi.Helpers
{
    public partial class ProductContext : DbContext
    {
        public virtual DbSet<ProductModel> ProductModel { get; set; }

        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("products");

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnType("text");

                entity.Property(e => e.CreatedAt);

                entity.Property(e => e.UpdatedAt);

            });
        }
    }
}
