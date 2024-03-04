using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SITechnicalTest.Models
{
    public class DbSupplier
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        [StringLength(2)]
        [Required]
        public string? CountryCode { get; set; }
        [Column(TypeName="date")]
        public DateTime DateCreated { get; set; }

        public ICollection<DbQuotation>? Quotations { get;set; }
    }
}
