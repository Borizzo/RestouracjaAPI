using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestouracjaAPI.Models
{
    public partial class RestourantdbContext : DbContext
    {
        public RestourantdbContext()
        {
        }

        public RestourantdbContext(DbContextOptions<RestourantdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PizzaMenu> PizzaMenus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaMenu>(entity =>
            {
                entity.ToTable("Pizza-Menu");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .HasColumnName("price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
