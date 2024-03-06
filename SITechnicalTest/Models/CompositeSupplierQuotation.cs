using SITechnicalTest_API.Models;

namespace SITechnicalTest.Models
{
    public class CompositeSupplierQuotation
    {
        public ICollection<Supplier> Suppliers { get; set; }
        public Quotation Quotation { get; set; }  
    }
}
