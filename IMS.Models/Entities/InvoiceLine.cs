using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace IMS.Models.Entities
{
    public class InvoiceLine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int InvoiceId { get; set; } // FK

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxPercent { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LineSubTotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LineTax { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LineTotal { get; set; }


        // Navigation
        //[JsonIgnore]
        //public Invoice Invoice { get; set; } = null!;
    }
}
