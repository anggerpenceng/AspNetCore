using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TrySimpleApi.Domain.Product.Entities;
using TrySimpleApi.Domain.Author.Entities;

namespace TrySimpleApi.Helpers
{
    public partial class ProductContext : DbContext
    {
        public virtual DbSet<AuthorEntity> AuthorEntities { get; set; }

        public virtual DbSet<ProductEntity> ProductEntities { get; set; }

        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Products");

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnType("text");

                entity.Property(e => e.CreatedAt);

                entity.Property(e => e.UpdatedAt);

            });

            modelBuilder.Entity<AuthorEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Authors");

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Position)
                    .IsRequired();

                entity.Property(e => e.CreatedAt);

                entity.Property(e => e.UpdatedAt);

            });


        }
    }
}
