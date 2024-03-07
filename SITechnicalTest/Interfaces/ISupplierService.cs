using Microsoft.AspNetCore.Mvc;
using SITechnicalTest_API.Models;

namespace SITechnicalTest.Interfaces
{
    public interface ISupplierService
    {
        Task<List<Supplier>> Get();
        Task<Supplier> GetByID(int id);
        Task<bool> Create(Supplier supplier);
        Task<bool> Delete(Supplier supplier);
        Task<bool> Update(Supplier supplier);
    }
}
