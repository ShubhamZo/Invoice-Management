using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Models.DTOs
{
    public class InvoiceResponse
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public decimal GrandTotal { get; set; }
        public List<InvoiceLineResponse> Lines { get; set; } = [];
    }
}
