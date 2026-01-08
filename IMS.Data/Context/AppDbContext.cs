using IMS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasMany(i => i.InvoiceLines).WithOne(I => I.Invoice).HasForeignKey(I => I.InvoiceId);
            });
        }
    }
}
