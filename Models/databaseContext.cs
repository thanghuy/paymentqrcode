using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace vn.edu.payment.qr.Models
{
    public partial class databaseContext : DbContext
    {
        public databaseContext()
        {
        }

        public databaseContext(DbContextOptions<databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Datasource=database.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Carts_CustomerId");

                entity.HasIndex(e => e.ProductId, "IX_Carts_ProductId");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Invoices_CustomerId");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasIndex(e => e.InvoiceId, "IX_InvoiceDetails_InvoiceId");

                entity.HasIndex(e => e.ProductId, "IX_InvoiceDetails_ProductId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CatalogId, "IX_Products_CatalogId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
