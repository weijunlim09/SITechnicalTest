using SITechnicalTest_API.Models;

namespace SITechnicalTest.Interfaces
{
    public interface IQuotationService
    {
        Task<List<Quotation>> Get();
        Task<Quotation> GetByID(int id);
        Task<bool> Create(Quotation quotation);
        Task<bool> Delete(Quotation quotation);
        Task<bool> Update(Quotation quotation);
    }
}
