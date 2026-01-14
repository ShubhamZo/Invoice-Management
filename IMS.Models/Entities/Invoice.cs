using IMS.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Models.Entities
{
    public class Invoice
    {
        [Key] // Primary Key
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string InvoiceNumber { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = null!;

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public InvoiceStatus Status { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxTotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GrandTotal { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAtUtc { get; set; }

        // Navigation Property
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
            = new List<InvoiceLine>();
    }
}
