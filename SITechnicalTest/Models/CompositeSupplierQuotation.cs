namespace SITechnicalTest.Models
{
    public class CompositeSupplierQuotation
    {
        public ICollection<DbSupplier> Suppliers { get; set; }
        public DbQuotation Quotation { get; set; }  
    }
}
