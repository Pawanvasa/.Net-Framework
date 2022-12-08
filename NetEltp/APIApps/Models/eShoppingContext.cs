using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIApps.Models
{
    public partial class eShoppingContext : DbContext
    {
        public eShoppingContext()
        {
        }

        public eShoppingContext(DbContextOptions<eShoppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=eShopping;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Manufacturer");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturerId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductUniqueId)
                    .HasName("PK__Product__8377B53A659F75E9");

                entity.ToTable("Product");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                /*  entity.HasOne(d => d.Category)
                          .WithMany(p => p.Products)
                          .HasForeignKey(d => d.CategoryId)
                          .OnDelete(DeleteBehavior.ClientSetNull)
                          .HasConstraintName("FK__Product__Categor__267ABA7A");*/
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SubCategory");

                entity.Property(e => e.SubCategoryId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubCategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubCatego__Categ__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
