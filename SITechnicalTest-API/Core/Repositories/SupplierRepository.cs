using Microsoft.EntityFrameworkCore;
using SITechnicalTest_API.Data;
using SITechnicalTest_API.Models;

namespace SITechnicalTest_API.Core.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        //public override async Task<List<Supplier>> GetAll()
        //{
        //    return await _dbContext.Suppliers.Where(x => x.CountryCode == "GB").ToListAsync();
        //}

        public async Task<List<Supplier>> GetByCountryCode(string countryCode)
        {
            return await _dbContext.Suppliers.Where(x => x.CountryCode == countryCode).ToListAsync();
        }
    }
}
