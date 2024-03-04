using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SITechnicalTest.Models
{
    public class DbQuotation
    {
        [Key]
        public int QuotationId { get; set; }
        public int SupplierId {  get; set; }    
        public string Product { get; set; }
        public decimal? CostPerUnit { get; set; }    
        public DbSupplier? Supplier { get; set; }
    }
}
