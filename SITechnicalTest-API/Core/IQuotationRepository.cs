using SITechnicalTest_API.Models;

namespace SITechnicalTest_API.Core
{
    public interface IQuotationRepository : IGenericRepository<Quotation>
    {
        Task<bool> HasCost(int id);
    }
}