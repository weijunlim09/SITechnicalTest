using SITechnicalTest_API.Data;
using SITechnicalTest_API.Models;

namespace SITechnicalTest_API.Core.Repositories
{
    public class QuotationRepository : GenericRepository<Quotation>, IQuotationRepository
    {
        public QuotationRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<bool> HasCost(int id)
        {
            Quotation? quotation = await _dbContext.Quotations.FindAsync(id);
            if (quotation == null) return false;
            return quotation.CostPerUnit != null;
        }
    }
}
