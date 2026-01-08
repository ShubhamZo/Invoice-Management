using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Models.DTOs
{
    public class InvoiceLineResponse
    {
        public string Description { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxPercent { get; set; }
    }
}
