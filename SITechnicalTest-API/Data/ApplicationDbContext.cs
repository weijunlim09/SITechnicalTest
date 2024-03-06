using Microsoft.EntityFrameworkCore;
using SITechnicalTest_API.Models;

namespace SITechnicalTest_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Quotation> Quotations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotation>()
                .HasOne(p => p.Supplier)
                .WithMany(x => x.Quotations).
                HasForeignKey(q => q.SupplierId);
        }
    }
}
