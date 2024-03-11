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
            modelBuilder.Entity<Supplier>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Quotation>()
               .Property(e => e.QuotationId)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Quotation>()
                .HasOne(p => p.Supplier)
                .WithMany(x => x.Quotations).
                HasForeignKey(q => q.SupplierId);

            modelBuilder.Entity<Supplier>().HasData(
               new Supplier { Id = 5, Name = "Supplier5", Email = "supplier5@gmail.com", CountryCode = "JP", DateCreated = new DateTime()},
               new Supplier { Id = 2,  Name = "Supplier2", Email = "supplier2@gmail.com", CountryCode = "JP", DateCreated = new DateTime() },
               new Supplier { Id = 4,  Name = "Supplier4", Email = "supplier4@gmail.com", CountryCode = "GB", DateCreated = new DateTime() },
               new Supplier { Id = 3,  Name = "Supplier3", Email = "supplier3@gmail.com", CountryCode = "GB", DateCreated = new DateTime() },
               new Supplier { Id = 1,  Name = "Supplier1", Email = "supplier1@gmail.com", CountryCode = "GB", DateCreated = new DateTime() }
            );
        }
    }
}
