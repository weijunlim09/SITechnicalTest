using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SITechnicalTest_API.Models
{
    public class Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int QuotationId { get; set; }
        public int SupplierId { get; set; }
        public string? Product { get; set; }
        public decimal? CostPerUnit { get; set; }
        [JsonIgnore]
        public Supplier? Supplier { get; set; }
    }
}
