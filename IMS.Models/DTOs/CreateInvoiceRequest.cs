using IMS.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Models.DTOs
{
    public class CreateInvoiceRequest
    {
        public string CustomerName { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public int Status { get; set; } // Status Value From Enum
        public List<CreateInvoiceLineRequest> Lines { get; set; } = [];
    }
}
