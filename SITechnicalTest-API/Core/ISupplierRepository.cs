using SITechnicalTest_API.Models;

namespace SITechnicalTest_API.Core
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<List<Supplier>> GetByCountryCode (string countryCode);
    }
}
