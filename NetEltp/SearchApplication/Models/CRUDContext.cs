using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SearchApplication.Models
{
    public partial class CRUDContext : DbContext
    {
        public CRUDContext()
        {
        }

        public CRUDContext(DbContextOptions<CRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=CRUD;Integrated Security=SSPI");
            }
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Manufature)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seller)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("seller");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
