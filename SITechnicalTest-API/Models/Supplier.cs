using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SITechnicalTest_API.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        [StringLength(2)]
        [Required]
        public string? CountryCode { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public ICollection<Quotation>? Quotations { get; set; }
    }
}
