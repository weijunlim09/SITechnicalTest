namespace SITechnicalTest_API.Core
{
    public interface IUnitOfWork
    {
        ISupplierRepository SupplierRepository { get; }
        IQuotationRepository QuotationRepository { get; }
        Task CompleteAsync();
    }
}
