﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SITechnicalTest_API.Models
{
    public class Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuotationId { get; set; }
        public int SupplierId { get; set; }
        public string? Product { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CostPerUnit { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
