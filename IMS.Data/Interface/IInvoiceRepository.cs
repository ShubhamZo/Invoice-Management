using IMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Data.Interface
{
    public interface IInvoiceRepository
    {
        Task AddInvoiceAsync(Invoice invoice);
        Task<Invoice?> GetByIdAsync(int id);
        Task<List<Invoice>> GetAllAsync();
        Task<int> GetMaxInvoiceSequenceAsync(int year);
    }
}
