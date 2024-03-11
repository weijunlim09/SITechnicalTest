namespace SITechnicalTest_API.Core
{
    public interface IUnitOfWork
    {
        ISupplierRepository SupplierRepository { get; }
        Task CompleteAsync();
    }
}
