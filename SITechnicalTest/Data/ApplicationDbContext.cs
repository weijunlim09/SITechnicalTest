using Microsoft.EntityFrameworkCore;
using SITechnicalTest.Models;

namespace SITechnicalTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<DbSupplier> Suppliers { get; set; }
        public DbSet<DbQuotation> Quotations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbSupplier>().HasData(
                new DbSupplier { Id = 1, Name = "Supplier1", Email = "supplier1@gmail.com", CountryCode = "GB", DateCreated = new DateTime(2021, 8, 18)},
                new DbSupplier { Id = 2, Name = "Supplier2", Email = "supplier2@gmail.com", CountryCode = "JP", DateCreated = new DateTime(2021, 8, 18) },
                new DbSupplier { Id = 3, Name = "Supplier3", Email = "supplier3@gmail.com", CountryCode = "GB", DateCreated = new DateTime(2021, 8, 19) },
                new DbSupplier { Id = 4, Name = "Supplier4", Email = "supplier4@gmail.com", CountryCode = "GB", DateCreated = new DateTime(2021, 8, 19) },
                new DbSupplier { Id = 5, Name = "Supplier5", Email = "supplier5@gmail.com", CountryCode = "JP", DateCreated = new DateTime(2021, 8, 19) }


                );

            modelBuilder.Entity<DbQuotation>()
                .HasOne(p => p.Supplier)
                .WithMany(x => x.Quotations).
                HasForeignKey(q => q.SupplierId);
        }
    }
}
